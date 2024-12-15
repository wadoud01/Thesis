using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SphereSliderSync : MonoBehaviour
{
    public Transform pandaBase;  // Reference to the Panda robot's base (panda_link0)
    public Transform sphere;     // Reference to the sphere
    public Slider sliderX, sliderY, sliderZ;  // Sliders for X, Y, Z
    public TextMeshProUGUI textMeshPro;       // Reference to the TextMeshProUGUI object

    private bool isUpdatingSphere = false;    // Flag to prevent recursive updates
    private bool isUpdatingSlider = false;

    void Start()
    {
        // Attach event listeners to sliders
        sliderX.onValueChanged.AddListener(OnSliderXChanged);
        sliderY.onValueChanged.AddListener(OnSliderYChanged);
        sliderZ.onValueChanged.AddListener(OnSliderZChanged);

        // Initialize sliders based on sphere's position
        UpdateSlidersFromSphere();
    }

    void Update()
    {
        if (!isUpdatingSlider)
        {
            UpdateSlidersFromSphere();
        }

        UpdateTextMeshPro();
    }

    private void UpdateSlidersFromSphere()
    {
        // Get the adjusted position of the sphere in meters
        Vector3 adjustedPosition = GetAdjustedSpherePosition();

        isUpdatingSlider = true; // Prevent recursive updates

        // Update sliders to match the sphere's position (convert meters to mm)
        sliderX.value = -adjustedPosition.x * 1000f;
        sliderY.value = adjustedPosition.y * 1000f;
        sliderZ.value = -adjustedPosition.z * 1000f;

        isUpdatingSlider = false;
    }

    private void UpdateSphereFromSliders()
    {
        // Get the new position from the sliders (convert mm to meters)
        float x = -sliderX.value / 1000f;
        float y = sliderY.value / 1000f;
        float z = -sliderZ.value / 1000f;

        // Transform the new position into the world space
        Vector3 localPosition = new Vector3(x, y, z); // Match axes directly without flipping
        Vector3 worldPosition = pandaBase.TransformPoint(localPosition);

        // Update the sphere's position
        sphere.position = worldPosition;
    }

    private void OnSliderXChanged(float value)
    {
        if (!isUpdatingSlider)
        {
            isUpdatingSphere = true;
            UpdateSphereFromSliders();
            isUpdatingSphere = false;
        }
    }

    private void OnSliderYChanged(float value)
    {
        if (!isUpdatingSlider)
        {
            isUpdatingSphere = true;
            UpdateSphereFromSliders();
            isUpdatingSphere = false;
        }
    }

    private void OnSliderZChanged(float value)
    {
        if (!isUpdatingSlider)
        {
            isUpdatingSphere = true;
            UpdateSphereFromSliders();
            isUpdatingSphere = false;
        }
    }

    private Vector3 GetAdjustedSpherePosition()
    {
        // Calculate the local position of the sphere with respect to the Panda's base
        Vector3 localPosition = pandaBase.InverseTransformPoint(sphere.position);

        // Return the adjusted position in meters (direct mapping without flipping)
        return new Vector3(localPosition.x, localPosition.y, localPosition.z);
    }

    private void UpdateTextMeshPro()
    {
        // Get the adjusted position
        Vector3 adjustedPosition = GetAdjustedSpherePosition();

        // Format the coordinates for display in meters
        string positionText = $"X: {adjustedPosition.x:F3} m\nY: {adjustedPosition.y:F3} m\nZ: {adjustedPosition.z:F3} m";

        // Update the TextMeshProUGUI object with the sphere's coordinates
        textMeshPro.text = positionText;

        // Optional: Position the TextMeshProUGUI object to follow the sphere (if in 3D space)
        textMeshPro.transform.position = sphere.position + new Vector3(0, 0.1f, 0);  // Adjust as needed
    }

    void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        sliderX.onValueChanged.RemoveListener(OnSliderXChanged);
        sliderY.onValueChanged.RemoveListener(OnSliderYChanged);
        sliderZ.onValueChanged.RemoveListener(OnSliderZChanged);
    }
}
