using UnityEngine;
using TMPro;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class UserInputHandler : MonoBehaviour
{
    public TMP_InputField inputFieldX;
    public TMP_InputField inputFieldY;
    public TMP_InputField inputFieldZ;
    public TMP_InputField conditionField; // Field for the numeric condition

    private ROSConnection ros;
    private const string rosTopic = "unity/coordinates";

    void Start()
    {
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PointMsg>(rosTopic);

        // Publish initial coordinates based on condition
        PublishCoordinates();
    }

    void Update()
    {
        // Optional: Check for any user-triggered events or input field changes to publish coordinates
    }

    private void PublishCoordinates()
    {
        // Get the input values from the input fields
        float x = float.Parse(inputFieldX.text);
        float y = float.Parse(inputFieldY.text);
        float z = float.Parse(inputFieldZ.text);
        string condition = conditionField.text.Trim(); // Read condition field value

        // Check if the condition is "1"
        if (condition == "1")
        {
            // Create a PointMsg with the input values
            PointMsg coordinates = new PointMsg(x, y, z);

            // Publish the coordinates to ROS
            ros.Publish(rosTopic, coordinates);

            // Print to the console for debugging
            Debug.Log($"Published coordinates: ({x}, {y}, {z})");
        }
        else
        {
            // Optionally log that publishing was skipped
            Debug.Log("Condition is not '1'. Coordinates not published.");
        }
    }
}
