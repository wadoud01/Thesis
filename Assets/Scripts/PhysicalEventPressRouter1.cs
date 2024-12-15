using UnityEngine;

public class PhysicalEventPressRouter1 : MonoBehaviour
{
    // Public reference to the UI panel you want to close
    public GameObject panelToClose;

    // Method to be called when the Close button is pressed
    public void OnCloseButtonPress()
    {
        if (panelToClose != null)
        {
            panelToClose.SetActive(false);  // Close the specified panel
        }
        else
        {
            Debug.LogWarning("No panel assigned to close.");
        }
    }
}
