using UnityEngine;
using RosMessageTypes.Sensor;  // Ensure you have the correct namespace for JointStateMsg

public class JointStateSubscriber : MonoBehaviour
{
    // Define your ArticulationBodies here
    public ArticulationBody[] jointArticulationBodies;

    // This method updates when a new JointStateMsg is received
    public void UpdateJointStates(JointStateMsg jointStateMsg)
    {
        Debug.Log("Received new JointStateMsg.");

        // Log the number of joints received
        int numReceivedJoints = jointStateMsg.name.Length;
        Debug.Log($"Number of joints received: {numReceivedJoints}");

        // Log the expected number of joints
        int numExpectedJoints = jointArticulationBodies.Length;
        Debug.Log($"Number of expected joints: {numExpectedJoints}");

        // Check if the number of received joints matches the expected
        if (numReceivedJoints != numExpectedJoints)
        {
            Debug.LogError($"Joint state message length ({numReceivedJoints}) does not match the number of robot joints ({numExpectedJoints}).");
            return; // Exit the method or add error handling
        }

        // Loop through each joint in the message
        for (int i = 0; i < numReceivedJoints; i++)
        {
            string jointName = jointStateMsg.name[i];
            double jointPosition = jointStateMsg.position[i];

            // Log each joint's name and position
            Debug.Log($"Joint {i + 1}: {jointName} - Position: {jointPosition}");

            // Update the corresponding ArticulationBody's position
            if (i < jointArticulationBodies.Length)
            {
                jointArticulationBodies[i].transform.localPosition = new Vector3(0, (float)jointPosition, 0); // Convert double to float if necessary
            }
        }
    }
    
}
