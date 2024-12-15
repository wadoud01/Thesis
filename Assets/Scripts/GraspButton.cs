using UnityEngine;
using UnityEngine.UI;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std; // for Bool message type

public class GraspButton : MonoBehaviour
{
    public Button graspButton; // Reference to your Grasp button
    private ROSConnection ros;
    private const string graspTopic = "/grasp_signal"; // Topic for grasp action
    private bool isGrasped = false; // Track the current grasp state

    void Start()
    {
        // Initialize ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<BoolMsg>(graspTopic);

        // Add listener to the button click event
        graspButton.onClick.AddListener(OnGraspButtonClick);
    }

    // This method will be called when the Grasp button is clicked
    void OnGraspButtonClick()
    {
        // Toggle the grasp state
        isGrasped = !isGrasped;

        // Create a Bool message with the toggled value (true for grasp, false for release)
        BoolMsg graspSignal = new BoolMsg
        {
            data = isGrasped
        };

        // Publish to the ROS topic "/grasp_signal"
        ros.Publish(graspTopic, graspSignal);

        // Optionally log a message to indicate the action
        if (isGrasped)
        {
            Debug.Log("Grasp button clicked! Gripper is closing.");
        }
        else
        {
            Debug.Log("Grasp button clicked! Gripper is opening.");
        }
    }

    void OnDestroy()
    {
        // Remove the listener to avoid memory leaks
        graspButton.onClick.RemoveListener(OnGraspButtonClick);
    }
}
