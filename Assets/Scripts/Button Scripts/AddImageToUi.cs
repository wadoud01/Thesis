using UnityEngine;
using UnityEngine.UI;

public class AddImageToUI : MonoBehaviour
{
    public Canvas canvas; // Reference to the Canvas
    public Sprite customSprite; // Reference to the Sprite to be used as the image

    void Start()
    {
        // Create a new GameObject
        GameObject newImageObject = new GameObject("CustomImage");

        // Add the Image component
        Image image = newImageObject.AddComponent<Image>();

        // Set the custom sprite
        image.sprite = customSprite;

        // Set the parent of the image to be the Canvas
        newImageObject.transform.SetParent(canvas.transform);

        // Optionally, set the size and position
        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 200); // Set the size
        rectTransform.anchoredPosition = new Vector2(0, 0); // Set the position
    }
}
