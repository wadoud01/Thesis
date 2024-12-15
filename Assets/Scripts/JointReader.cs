using UnityEngine;
using System.Collections.Generic;

public class JointPositionLogger : MonoBehaviour
{
    // Dictionary to map joint names to their corresponding ArticulationBody components
    private Dictionary<string, ArticulationBody> jointArticulations;

    void Start()
    {
        // Initialize joint mappings
        jointArticulations = new Dictionary<string, ArticulationBody>
        {
            { "panda_joint1", GameObject.Find("panda_joint1")?.GetComponent<ArticulationBody>() },
            { "panda_joint2", GameObject.Find("panda_joint2")?.GetComponent<ArticulationBody>() },
            { "panda_joint3", GameObject.Find("panda_joint3")?.GetComponent<ArticulationBody>() },
            { "panda_joint4", GameObject.Find("panda_joint4")?.GetComponent<ArticulationBody>() },
            { "panda_joint5", GameObject.Find("panda_joint5")?.GetComponent<ArticulationBody>() },
            { "panda_joint6", GameObject.Find("panda_joint6")?.GetComponent<ArticulationBody>() },
            { "panda_joint7", GameObject.Find("panda_joint7")?.GetComponent<ArticulationBody>() },
            { "panda_finger_joint1", GameObject.Find("panda_finger_joint1")?.GetComponent<ArticulationBody>() },
            { "panda_finger_joint2", GameObject.Find("panda_finger_joint2")?.GetComponent<ArticulationBody>() }
        };

        // Log a message if any ArticulationBody was not found
        foreach (var kvp in jointArticulations)
        {
            if (kvp.Value == null)
            {
                Debug.LogError($"ArticulationBody for {kvp.Key} not found!");
            }
        }
    }

    void Update()
    {
        LogJointPositions();
    }

    private void LogJointPositions()
    {
        // Accumulate joint positions
        string jointPositionsLog = "Joint Positions: ";
        
        foreach (var kvp in jointArticulations)
        {
            if (kvp.Value != null)
            {
                // Read the current position of the joint
                ArticulationReducedSpace jointPosition = kvp.Value.jointPosition;

                // Convert joint positions from radians to degrees
                float positionInDegrees = jointPosition[0] * Mathf.Rad2Deg;

                // Append the joint position to the log string
                jointPositionsLog += $"{kvp.Key}: {positionInDegrees:F2} degrees, ";
            }
        }

        // Remove the trailing comma and space
        if (jointPositionsLog.EndsWith(", "))
        {
            jointPositionsLog = jointPositionsLog.Substring(0, jointPositionsLog.Length - 2);
        }

        // Log all joint positions in one line
        Debug.Log(jointPositionsLog);
    }
}
