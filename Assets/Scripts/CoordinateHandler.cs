using UnityEngine;
using TMPro;  // Add this line to use TextMeshPro
using UnityEngine.UI;

public class CoordinateHandler : MonoBehaviour
{
    public TMP_InputField inputFieldX;  // TextMeshPro InputField
    public TMP_InputField inputFieldY;  // TextMeshPro InputField
    public TMP_InputField inputFieldZ;  // TextMeshPro InputField
    public Button buttonInsert;
    public Button buttonMove;

    private float x, y, z;

    void Start()
    {
        buttonInsert.onClick.AddListener(InsertCoordinates);
        buttonMove.onClick.AddListener(MoveToCoordinates);
    }

    void InsertCoordinates()
    {
        // For simplicity, we will just log the coordinates when the Insert button is clicked
        Debug.Log("Insert button clicked");
    }

    void MoveToCoordinates()
    {
        if (float.TryParse(inputFieldX.text, out x) && 
            float.TryParse(inputFieldY.text, out y) && 
            float.TryParse(inputFieldZ.text, out z))
        {
            Debug.Log($"Moving to coordinates: X={x}, Y={y}, Z={z}");
        }
        else
        {
            Debug.LogError("Invalid input. Please enter valid numbers for X, Y, and Z.");
        }
    }
}
