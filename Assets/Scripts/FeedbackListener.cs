using UnityEngine;
using TMPro; // Import TextMeshPro namespace
using Unity.Robotics.ROSTCPConnector;
using RosMessageTypes.Std;

public class FeedbackListener : MonoBehaviour
{
    public string feedbackTopic = "/unity_feedback";  // ROS topic name for feedback
    public TMP_Text feedbackText;                     // Reference to the TMP Text for displaying feedback

    private ROSConnection ros;

    void Start()
    {
        // Initialize the ROS connection
        ros = ROSConnection.GetOrCreateInstance();
        
        // Subscribe to the feedback topic
        ros.Subscribe<StringMsg>(feedbackTopic, OnFeedbackReceived);
    }

    private void OnFeedbackReceived(StringMsg msg)
    {
        // Process the received feedback message
        string feedback = msg.data;
        Debug.Log($"Feedback received: {feedback}");

        // Display feedback in the UI
        StartCoroutine(DisplayFeedback(feedback));
    }

    private System.Collections.IEnumerator DisplayFeedback(string feedback)
    {
        if (feedbackText != null)
        {
            // Show the feedback
            feedbackText.text = feedback;

            // Wait for 2 seconds
            yield return new WaitForSeconds(3);

            // Clear the feedback
            feedbackText.text = "";
        }
    }
}
