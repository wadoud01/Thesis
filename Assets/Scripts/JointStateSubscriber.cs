using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using System.Collections.Generic;

public class JointStateSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/joint_states";
    public GameObject robot;
    private ArticulationBody[] jointArticulationBodies;

    void Start()
    {
        ros = ROSConnection.instance;
        ros.Subscribe<JointStateMsg>(topicName, UpdateJointStates);

        // Initialize the joints
        jointArticulationBodies = robot.GetComponentsInChildren<ArticulationBody>();
    }

    void UpdateJointStates(JointStateMsg jointStateMessage)
    {
        // Ensure the number of joints in the message matches the robot's joints
        if (jointStateMessage.position.Length != jointArticulationBodies.Length)
        {
            Debug.LogError("Joint state message length does not match the number of robot joints.");
            return;
        }

        // Update each joint's target position
        for (int i = 0; i < jointArticulationBodies.Length; i++)
        {
            var jointDrive = jointArticulationBodies[i].xDrive;
            jointDrive.target = (float)(jointStateMessage.position[i] * Mathf.Rad2Deg); // Convert from radians to degrees
            jointArticulationBodies[i].xDrive = jointDrive;
        }
    }
}
