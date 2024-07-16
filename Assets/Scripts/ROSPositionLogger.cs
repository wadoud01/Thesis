using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using System.Collections.Generic;

public class ROSVelocityLogger : MonoBehaviour
{
    // ROS connection variable
    private ROSConnection ros;

    // Dictionary to map joint names to their corresponding transforms in Unity
    private Dictionary<string, Transform> jointTransforms;
    private Dictionary<string, float> jointVelocities;
    private Dictionary<string, float> jointEfforts;

    void Start()
    {
        // Initialize ROS connection
        ros = ROSConnection.GetOrCreateInstance();

        // Subscribe to the joint_states topic
        ros.Subscribe<JointStateMsg>("/joint_states", UpdateJointStates);

        // Initialize joint mappings (replace with actual joint names in Unity)
        jointTransforms = new Dictionary<string, Transform>
        {
            { "panda_joint1", GameObject.Find("panda_joint1").transform },
            { "panda_joint2", GameObject.Find("panda_joint2").transform },
            { "panda_joint3", GameObject.Find("panda_joint3").transform },
            { "panda_joint4", GameObject.Find("panda_joint4").transform },
            { "panda_joint5", GameObject.Find("panda_joint5").transform },
            { "panda_joint6", GameObject.Find("panda_joint6").transform },
            { "panda_joint7", GameObject.Find("panda_joint7").transform },
            { "panda_finger_joint1", GameObject.Find("panda_finger_joint1").transform },
            { "panda_finger_joint2", GameObject.Find("panda_finger_joint2").transform }
        };

        // Initialize dictionaries for velocities and efforts
        jointVelocities = new Dictionary<string, float>();
        jointEfforts = new Dictionary<string, float>();
        foreach (var joint in jointTransforms.Keys)
        {
            jointVelocities[joint] = 0f;
            jointEfforts[joint] = 0f;
        }
    }

    // This method updates when a new JointStateMsg is received
    private void UpdateJointStates(JointStateMsg jointStateMsg)
    {
        // Log the received velocities and efforts
        for (int i = 0; i < jointStateMsg.velocity.Length; i++)
        {
            string jointName = jointStateMsg.name[i];
            double jointVelocity = jointStateMsg.velocity[i];
            double jointEffort = jointStateMsg.effort[i];

            Debug.Log($"Received Joint State: Joint {jointName} - Velocity: {jointVelocity}, Effort: {jointEffort}");

            // Update the joint velocity and effort in the dictionaries
            if (jointVelocities.ContainsKey(jointName))
            {
                jointVelocities[jointName] = (float)jointVelocity;
            }
            else
            {
                Debug.LogWarning($"Joint {jointName} not found in the jointVelocities dictionary.");
            }

            if (jointEfforts.ContainsKey(jointName))
            {
                jointEfforts[jointName] = (float)jointEffort;
            }
            else
            {
                Debug.LogWarning($"Joint {jointName} not found in the jointEfforts dictionary.");
            }
        }
    }

    void Update()
    {
        // Integrate velocities and efforts over time to update joint states
        float deltaTime = Time.deltaTime;

        foreach (var joint in jointTransforms.Keys)
        {
            if (jointTransforms[joint] != null)
            {
                float velocity = jointVelocities[joint];
                float effort = jointEfforts[joint];
                Transform jointTransform = jointTransforms[joint];

                // Example: Adjust joint rotation based on velocity or effort
                // (Implement your control logic here based on velocity and effort)
            }
        }
    }
}
