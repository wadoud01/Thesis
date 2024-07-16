using UnityEngine;
using RosMessageTypes.Sensor;  // Make sure this matches your ROS message type namespace

public class ROSTopicDebugger : MonoBehaviour
{
    public void PrintJointState(JointStateMsg jointStateMsg)
    {
        Debug.Log("Received new JointStateMsg.");

        // Log the number of joints received
        int numReceivedJoints = jointStateMsg.name.Length;
        Debug.Log($"Number of joints received: {numReceivedJoints}");

        // Log each joint's name and position
        for (int i = 0; i < numReceivedJoints; i++)
        {
            string jointName = jointStateMsg.name[i];
            double jointPosition = jointStateMsg.position[i];

            // Log each joint's name and position
            Debug.Log($"Joint {i + 1}: {jointName} - Position: {jointPosition}");
        }
    }
}
