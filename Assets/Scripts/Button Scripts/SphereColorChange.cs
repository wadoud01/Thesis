using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class SphereColorChange : MonoBehaviour, IMixedRealityPointerHandler
{
    // Public reference to the sphere's Renderer component, draggable in the Inspector
    public Renderer sphereRenderer;

    // Colors for original and touched states
    public Color originalColor = Color.white;
    public Color touchedColor = Color.red;

    private void Start()
    {
        // Ensure the sphereRenderer is assigned
        if (sphereRenderer == null)
        {
            Debug.LogError("Renderer not assigned. Please drag the sphere object into the Inspector.");
            return;
        }

        // Set the original color of the sphere
        sphereRenderer.material.color = originalColor;
    }

    // This function is called when the pointer clicks or touches the sphere
    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        sphereRenderer.material.color = touchedColor;
    }

    // This function is called when the pointer is released from the sphere
    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        sphereRenderer.material.color = originalColor;
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        // Optionally handle dragging if needed
    }

    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        // Handle pointer clicked if needed
    }
}
