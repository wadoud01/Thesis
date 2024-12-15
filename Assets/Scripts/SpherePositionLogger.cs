using UnityEngine;
using TMPro;

public class SpherePositionHandler : MonoBehaviour
{
    public Transform pandaBase;  // Reference to the Panda robot's base (panda_link0)
    public Transform sphere;     // Reference to the sphere
    public TextMeshProUGUI textMeshPro;  // Reference to the TextMeshProUGUI object

    void Update()
    {
        // Get the adjusted position
        Vector3 adjustedPosition = GetAdjustedSpherePosition();

        // Log the adjusted coordinates in the Unity console
        Debug.Log($"Sphere Position (adjusted) relative to Panda Base: X={adjustedPosition.x:F3}, Y={adjustedPosition.y:F3}, Z={adjustedPosition.z:F3}");

        // Format the coordinates for display
        string positionText = $"X: {adjustedPosition.x*100:F1} cm\nY: {adjustedPosition.y*100:F1} cm\nZ: {adjustedPosition.z*100:F1} cm";

        // Update the TextMeshProUGUI object with the sphere's coordinates
        textMeshPro.text = positionText;

        // Optional: Position the TextMeshProUGUI object to follow the sphere (if in 3D space)
        textMeshPro.transform.position = sphere.position + new Vector3(0, 0.1f, 0);  // Adjust as needed
    }

    // Method to get the adjusted sphere position
    public Vector3 GetAdjustedSpherePosition()
    {
        // Calculate the local position of the sphere with respect to the Panda's base
        Vector3 localPosition = pandaBase.InverseTransformPoint(sphere.position);

        // Adjust the coordinates to match the desired frame
        float adjustedX = -localPosition.x;  // Flip X
        float adjustedY = -localPosition.z;  // Use Z as Y (height)
        float adjustedZ = localPosition.y;  // Flip Y (now Z)

        // Return the adjusted position
        return new Vector3(adjustedX, adjustedY, adjustedZ);
    }
}
