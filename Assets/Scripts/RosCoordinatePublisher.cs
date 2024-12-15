using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Geometry;

public class SliderValuePublisher : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    public TMP_Text valueTextX;
    public TMP_Text valueTextY;
    public TMP_Text valueTextZ;
    public Button insertButton;

    private ROSConnection ros;
    private const string rosTopic = "unity_coordinates";

    private float x;
    private float y;
    private float z;

    void Start()
    {
        // Initialize ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        ros.RegisterPublisher<PointMsg>(rosTopic);

        // Initialize the text with the current slider values
        UpdateSliderValueTextX(sliderX.value);
        UpdateSliderValueTextY(sliderY.value);
        UpdateSliderValueTextZ(sliderZ.value);

        // Add listeners to the sliders
        sliderX.onValueChanged.AddListener(UpdateSliderValueTextX);
        sliderY.onValueChanged.AddListener(UpdateSliderValueTextY);
        sliderZ.onValueChanged.AddListener(UpdateSliderValueTextZ);

        // Attach the OnInsertButtonClicked method to the button's onClick event
        insertButton.onClick.AddListener(OnInsertButtonClicked);
    }

    void UpdateSliderValueTextX(float value)
    {
        x = value / 1000.0f; // Convert mm to meters
        valueTextX.text = $"X: {value/10:F1} cm";
    }

    void UpdateSliderValueTextY(float value)
    {
        y = value / 1000.0f; // Convert mm to meters
        valueTextY.text = $"Y: {value / 10:F1} cm";

    }

    void UpdateSliderValueTextZ(float value)
    {
        z = value / 1000.0f; // Convert mm to meters
        valueTextZ.text = $"Z: {value/10:F1} cm";
    }

    public void OnInsertButtonClicked()
    {
        // Create a PointMsg with the current slider values
        PointMsg coordinates = new PointMsg
        {
            x = x,
            y = y,
            z = z
        };

        // Publish the coordinates to ROS
        ros.Publish(rosTopic, coordinates);

        // Optionally, log a message to indicate that the publish was successful
        Debug.Log($"Coordinates published to ROS topic {rosTopic}: ({x}, {y}, {z})");
    }

    void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        sliderX.onValueChanged.RemoveListener(UpdateSliderValueTextX);
        sliderY.onValueChanged.RemoveListener(UpdateSliderValueTextY);
        sliderZ.onValueChanged.RemoveListener(UpdateSliderValueTextZ);
    }
}
