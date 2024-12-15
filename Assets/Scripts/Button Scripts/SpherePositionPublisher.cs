using UnityEngine;
using UnityEngine.UI; // Required for UI elements
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class SpherePositionPublisher : MonoBehaviour
{
    public Transform pandaBase;  // Reference to the Panda robot's base (panda_link0)
    public Transform sphere;     // Reference to the sphere

    public Button pointButton;   // Reference to the UI Button

    private ROSConnection ros;
    public string topicName = "unity_coordinates";

    void Start()
    {
        // Start the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PointMsg>(topicName);

        // Register the OnPointButtonClick method to the button's onClick event
        pointButton.onClick.AddListener(OnPointButtonClick);
    }

    public void OnPointButtonClick()
    {
        // Calculate the local position of the sphere with respect to the Panda's base
        Vector3 localPosition = pandaBase.InverseTransformPoint(sphere.position);

        // Correct the coordinate mapping
        float rosX = -localPosition.x;  // Unity's X -> ROS's X
        float rosY = -localPosition.z;   // Unity's Z -> ROS's Y
        float rosZ = localPosition.y;   // Unity's Y -> ROS's Z

        // Publish the converted coordinates to ROS
        PublishCoordinates(rosX, rosY, rosZ);
    }

    private void PublishCoordinates(float x, float y, float z)
    {
        PointMsg coordinates = new PointMsg
        {
            x = x,
            y = y,
            z = z
        };

        // Send message to ROS
        ros.Publish(topicName, coordinates);

        // Log a message to indicate that the publish was successful
        Debug.Log($"Coordinates published to ROS topic {topicName}: (X: {x:F3}, Y: {y:F3}, Z: {z:F3})");
    }

    void OnDestroy()
    {
        // Remove listener to avoid memory leaks
        pointButton.onClick.RemoveListener(OnPointButtonClick);
    }
}
