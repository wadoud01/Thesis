using UnityEngine;
using UnityEngine.UI;

public class IDBH : MonoBehaviour
{
    public Slider targetSlider;  // Reference to the slider this script controls
    public Button incrementButton; // Reference to the '+' button
    public Button decrementButton; // Reference to the '-' button
    public float stepSize = 10.0f; // The step value for each button click

    void Start()
    {
        // Add listeners to the buttons
        incrementButton.onClick.AddListener(IncrementSlider);
        decrementButton.onClick.AddListener(DecrementSlider);
    }

    void IncrementSlider()
    {
        if (targetSlider != null)
        {
            // Increase the slider value by the step size, respecting the max value
            targetSlider.value = Mathf.Min(targetSlider.maxValue, targetSlider.value + stepSize);
        }
    }

    void DecrementSlider()
    {
        if (targetSlider != null)
        {
            // Decrease the slider value by the step size, respecting the min value
            targetSlider.value = Mathf.Max(targetSlider.minValue, targetSlider.value - stepSize);
        }
    }

    void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        incrementButton.onClick.RemoveListener(IncrementSlider);
        decrementButton.onClick.RemoveListener(DecrementSlider);
    }
}
