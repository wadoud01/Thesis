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
        // Log the received positions
        for (int i = 0; i < jointStateMsg.position.Length; i++)
        {
            string jointName = jointStateMsg.name[i];
            double jointPosition = jointStateMsg.position[i];

            Debug.Log($"Received Joint Position: Joint {jointName} - Position: {jointPosition} radians");

            // Update the joint position
            if (jointArticulations.ContainsKey(jointName))
            {
                ArticulationBody jointArticulation = jointArticulations[jointName];
                ArticulationDrive drive = jointArticulation.xDrive;
                drive.target = -(float)(jointPosition * Mathf.Rad2Deg); // Convert radians to degrees and multiply by -1
                jointArticulation.xDrive = drive;
            }
            else
            {
                Debug.LogWarning($"Joint {jointName} not found in the jointArticulations dictionary.");
            }
        }
    }
}
