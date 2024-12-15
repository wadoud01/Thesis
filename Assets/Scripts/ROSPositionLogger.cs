using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using System.Collections.Generic;

public class ROSPositionLogger : MonoBehaviour
{
    // ROS connection variable
    private ROSConnection ros;

    // Dictionary to map joint names to their corresponding ArticulationBody components in Unity
    private Dictionary<string, ArticulationBody> jointArticulations;

    // Vector for sign inversion
    private static readonly int[] signVector = { 1, -1, 1, 1, 1, 1, -1 };

    void Start()
    {
        // Initialize ROS connection
        ros = ROSConnection.GetOrCreateInstance();

        // Subscribe to the joint_states topic
        ros.Subscribe<JointStateMsg>("/joint_states", UpdateJointStates);

        // Initialize joint mappings (replace with actual joint names in Unity)
        jointArticulations = new Dictionary<string, ArticulationBody>
        {
            { "panda_joint1", GameObject.Find("panda_joint1").GetComponent<ArticulationBody>() },
            { "panda_joint2", GameObject.Find("panda_joint2").GetComponent<ArticulationBody>() },
            { "panda_joint3", GameObject.Find("panda_joint3").GetComponent<ArticulationBody>() },
            { "panda_joint4", GameObject.Find("panda_joint4").GetComponent<ArticulationBody>() },
            { "panda_joint5", GameObject.Find("panda_joint5").GetComponent<ArticulationBody>() },
            { "panda_joint6", GameObject.Find("panda_joint6").GetComponent<ArticulationBody>() },
            { "panda_joint7", GameObject.Find("panda_joint7").GetComponent<ArticulationBody>() },
            { "panda_finger_joint1", GameObject.Find("panda_finger_joint1").GetComponent<ArticulationBody>() },
            { "panda_finger_joint2", GameObject.Find("panda_finger_joint2").GetComponent<ArticulationBody>() }
        };
    }

    // This method updates when a new JointStateMsg is received
    private void UpdateJointStates(JointStateMsg jointStateMsg)
    {
        string logMessage = "Joint Positions:";

        // Update the joint position and log the positions
        for (int i = 0; i < jointStateMsg.position.Length; i++)
        {
            string jointName = jointStateMsg.name[i];
            double jointPosition = jointStateMsg.position[i];

            // Handle finger joints separately (do not convert to degrees)
            if (jointName == "panda_finger_joint1" || jointName == "panda_finger_joint2")
            {
                // Add to log message
                logMessage += $"\n{jointName}: {jointPosition:F2} radians";

                // Update the joint position without converting to degrees
                if (jointArticulations.ContainsKey(jointName))
                {
                    ArticulationBody jointArticulation = jointArticulations[jointName];
                    ArticulationDrive drive = jointArticulation.xDrive;
                    drive.target = (float)jointPosition; // No conversion needed
                    jointArticulation.xDrive = drive;
                }
            }
            else
            {
                // Convert radians to degrees and apply sign inversion if needed
                float jointPositionInDegrees = (float)(jointPosition * Mathf.Rad2Deg) * signVector[i];

                // Add to log message
                logMessage += $"\n{jointName}: {jointPositionInDegrees:F2} degrees";

                // Update the joint position
                if (jointArticulations.ContainsKey(jointName))
                {
                    ArticulationBody jointArticulation = jointArticulations[jointName];
                    ArticulationDrive drive = jointArticulation.xDrive;
                    drive.target = -jointPositionInDegrees; // Apply the sign-inverted angle
                    jointArticulation.xDrive = drive;
                }
            }
        }

        // Print all joint positions in one go
        Debug.Log(logMessage);
    }
}
