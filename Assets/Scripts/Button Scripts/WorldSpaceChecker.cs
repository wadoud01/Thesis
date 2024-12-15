using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WorkspaceChecker : MonoBehaviour
{
    // Define the workspace boundaries (based on the adjusted coordinates)
    private float xMin = -0.700f;
    private float xMax = 0.700f;
    private float yMin = -0.700f;
    private float yMax = 0.700f;
    private float zMin = -0.20f;
    private float zMax = 0.900f;

    // Reference to the SpherePositionHandler script
    public SpherePositionHandler spherePositionHandler;

    // UI element for out-of-workspace warning
    public GameObject outOfWorkspacePanel;

    // Reference to the close button in the panel
    public Button closeButton;

    // Reference to the Panda robot model (drag panda0 here)
    public GameObject pandaRobot;

    // Store the original materials of the Panda robot
    private Material[][] originalMaterials;

    // Red material for signaling
    private Material redMaterial;

    // Coroutines for panel auto-close and pulsing effect
    private Coroutine autoCloseCoroutine; 
    private Coroutine pulseCoroutine;

    void Start()
    {
        // Ensure the panel is hidden by default
        outOfWorkspacePanel.SetActive(false);

        // Attach the ClosePanel method to the close button's onClick event
        if (closeButton != null)
        {
            closeButton.onClick.AddListener(ClosePanel);
        }

        // Store the original Panda robot materials
        if (pandaRobot != null)
        {
            Renderer[] pandaRenderers = pandaRobot.GetComponentsInChildren<Renderer>();
            originalMaterials = new Material[pandaRenderers.Length][];

            for (int i = 0; i < pandaRenderers.Length; i++)
            {
                originalMaterials[i] = pandaRenderers[i].materials;
            }
        }

        // Create a red material instance dynamically
        redMaterial = new Material(Shader.Find("Standard"));
        redMaterial.color = Color.red;  // Set the material color to red
    }

    void Update()
    {
        // Continuously check the sphere's position in the Update method
        CheckSpherePosition();
    }

    // Method to check if the sphere is within the workspace
    private bool IsWithinWorkspace(float x, float y, float z)
    {
        return x >= xMin && x <= xMax && y >= yMin && y <= yMax && z >= zMin && z <= zMax;
    }

    // Method to check the sphere's position
    private void CheckSpherePosition()
    {
        // Get the adjusted sphere position from the SpherePositionHandler
        Vector3 adjustedPosition = spherePositionHandler.GetAdjustedSpherePosition();

        // Extract coordinates from the adjusted position
        float x = adjustedPosition.x;
        float y = adjustedPosition.y;
        float z = adjustedPosition.z;

        // Check if the sphere is within the workspace
        if (IsWithinWorkspace(x, y, z))
        {
            outOfWorkspacePanel.SetActive(false);  // Hide the panel if within workspace

            // Stop pulsing and reset Panda robot color
            StopPulsing();
            ResetPandaColor();
        }
        else
        {
            outOfWorkspacePanel.SetActive(true);  // Show the panel if out of workspace

            // Start the auto-close coroutine if not already running
            if (autoCloseCoroutine != null)
            {
                StopCoroutine(autoCloseCoroutine); // Stop any existing coroutine
            }
            autoCloseCoroutine = StartCoroutine(AutoClosePanelAfterDelay(10f));  // Close after 10 seconds

            // Start pulsing the Panda robot color continuously
            StartPulsing();
        }
    }

    // Method to close the panel when the close button is clicked
    private void ClosePanel()
    {
        if (outOfWorkspacePanel != null)
        {
            outOfWorkspacePanel.SetActive(false);  // Hide the panel when close button is clicked
        }

        // Stop the auto-close coroutine if it's still running
        if (autoCloseCoroutine != null)
        {
            StopCoroutine(autoCloseCoroutine);
            autoCloseCoroutine = null;
        }

        // Stop pulsing and reset Panda robot color
        StopPulsing();
        ResetPandaColor();
    }

    // Coroutine to auto-close the panel after a delay
    private IEnumerator AutoClosePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        outOfWorkspacePanel.SetActive(false);  // Hide the panel after the delay

        // Stop pulsing and reset Panda robot color
        StopPulsing();
        ResetPandaColor();
    }

    // Start pulsing the Panda robot color
    private void StartPulsing()
    {
        if (pulseCoroutine == null) // Only start pulsing if it's not already running
        {
            pulseCoroutine = StartCoroutine(PulseEffect());  // Start continuous pulsing
        }
    }

    // Stop pulsing and reset Panda robot color
    private void StopPulsing()
    {
        if (pulseCoroutine != null)
        {
            StopCoroutine(pulseCoroutine);
            pulseCoroutine = null;
        }
        ResetPandaColor();
    }

    // Coroutine to pulse the Panda robot color continuously
    private IEnumerator PulseEffect()
    {
        Renderer[] pandaRenderers = pandaRobot.GetComponentsInChildren<Renderer>();

        while (true)  // Continuous pulsing
        {
            float lerpFactor = Mathf.PingPong(Time.time * 2f, 1f);  // Slower pulse with PingPong
            Color lerpedColor = Color.Lerp(originalMaterials[0][0].color, Color.red, lerpFactor);

            foreach (Renderer pandaRenderer in pandaRenderers)
            {
                Material[] newMaterials = new Material[pandaRenderer.materials.Length];
                for (int i = 0; i < newMaterials.Length; i++)
                {
                    newMaterials[i] = new Material(pandaRenderer.materials[i]);
                    newMaterials[i].color = lerpedColor;
                }
                pandaRenderer.materials = newMaterials;
            }

            yield return null;  // Continue pulsing in the next frame
        }
    }

    // Method to reset Panda robot color to original
    private void ResetPandaColor()
    {
        if (pandaRobot != null && originalMaterials != null)
        {
            Renderer[] pandaRenderers = pandaRobot.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < pandaRenderers.Length; i++)
            {
                pandaRenderers[i].materials = originalMaterials[i];  // Restore original materials
            }

            Debug.Log("Panda color reset to original.");
        }
        else
        {
            Debug.LogWarning("Panda robot or original materials are not set.");
        }
    }
}
