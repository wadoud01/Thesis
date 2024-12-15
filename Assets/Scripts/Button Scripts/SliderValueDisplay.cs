using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderValueDisplay : MonoBehaviour
{
    public Slider sliderX;
    public Slider sliderY;
    public Slider sliderZ;
    public TMP_Text valueTextX;
    public TMP_Text valueTextY;
    public TMP_Text valueTextZ;

    void Start()
    {
        // Initialize the text with the current slider values
        UpdateSliderValueTextX(sliderX.value);
        UpdateSliderValueTextY(sliderY.value);
        UpdateSliderValueTextZ(sliderZ.value);

        // Add listeners to the sliders
        sliderX.onValueChanged.AddListener(UpdateSliderValueTextX);
        sliderY.onValueChanged.AddListener(UpdateSliderValueTextY);
        sliderZ.onValueChanged.AddListener(UpdateSliderValueTextZ);
    }

    void UpdateSliderValueTextX(float value)
    {
        valueTextX.text = $"X: {Mathf.RoundToInt(value)} mm";
    }

    void UpdateSliderValueTextY(float value)
    {
        valueTextY.text = $"Y: {Mathf.RoundToInt(value)} mm";
    }

    void UpdateSliderValueTextZ(float value)
    {
        valueTextZ.text = $"Z: {Mathf.RoundToInt(value)} mm";
    }

    void OnDestroy()
    {
        // Remove listeners to avoid memory leaks
        sliderX.onValueChanged.RemoveListener(UpdateSliderValueTextX);
        sliderY.onValueChanged.RemoveListener(UpdateSliderValueTextY);
        sliderZ.onValueChanged.RemoveListener(UpdateSliderValueTextZ);
    }
}
