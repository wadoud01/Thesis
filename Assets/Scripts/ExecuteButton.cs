using UnityEngine;
using UnityEngine.UI;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std; // for Bool message type

public class ExecuteButton : MonoBehaviour
{
    public Button executeButton; // Reference to your button
    private ROSConnection ros;
    private const string executeTopic = "/execute_signal";

    void Start()
    {
        // Initialize ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<BoolMsg>(executeTopic);

        // Add listener to the button click event
        executeButton.onClick.AddListener(OnExecuteButtonClick);
    }

    // This method will be called when the execute button is clicked
    void OnExecuteButtonClick()
    {
        // Create a Bool message with value true
        BoolMsg executeSignal = new BoolMsg
        {
            data = true
        };

        // Publish to the ROS topic "/execute_signal"
        ros.Publish(executeTopic, executeSignal);

        // Optionally log a message to indicate it's been sent
        Debug.Log("Execute button clicked! Sending execute signal to ROS.");
    }

    void OnDestroy()
    {
        // Remove the listener to avoid memory leaks
        executeButton.onClick.RemoveListener(OnExecuteButtonClick);
    }
}
