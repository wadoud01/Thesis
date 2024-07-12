using UnityEngine;
using System.Collections.Generic;

public class FrankaPandaController : MonoBehaviour
{
    public GameObject robot;
    private List<(ArticulationBody, Vector3, Quaternion)> initialStates;
    private Vector3 initialRobotPosition;
    private Quaternion initialRobotRotation;
    private ArticulationBody rootArticulationBody;

    void Start()
    {
        GetInitialStates();
    }

    void GetInitialStates()
    {
        // Store the initial state of the robot
        initialRobotPosition = robot.transform.position;
        initialRobotRotation = robot.transform.rotation;

        // Store the initial state of all ArticulationBodies in the robot
        initialStates = new List<(ArticulationBody, Vector3, Quaternion)>();
        ArticulationBody[] articulationBodies = robot.GetComponentsInChildren<ArticulationBody>();
        foreach (ArticulationBody body in articulationBodies)
        {
            initialStates.Add((body, body.transform.localPosition, body.transform.localRotation));
            if (body.isRoot)
            {
                rootArticulationBody = body;
            }
        }
    }

    public void ResetToInitialState()
    {
        // Reset the robot to its initial state
        robot.transform.position = initialRobotPosition;
        robot.transform.rotation = initialRobotRotation;

        // Reset all ArticulationBodies in the robot to their initial state
        foreach (var state in initialStates)
        {
            // Reset the position and rotation
            state.Item1.transform.localPosition = state.Item2;
            state.Item1.transform.localRotation = state.Item3;

            // Reset the velocity and angular velocity
            state.Item1.velocity = Vector3.zero;
            state.Item1.angularVelocity = Vector3.zero;

            // Reset joint positions, accelerations, forces, and velocities
            state.Item1.jointPosition = new ArticulationReducedSpace(0f, 0f, 0f);
            state.Item1.jointForce = new ArticulationReducedSpace(0f, 0f, 0f);
            state.Item1.jointVelocity = new ArticulationReducedSpace(0f, 0f, 0f);

            // If the ArticulationBody is not the root, reset the xDrive
            if (state.Item1 != rootArticulationBody)
            {
                var drive = state.Item1.xDrive;
                drive.target = 0f;
                state.Item1.xDrive = drive;
            }
        }

        // Use TeleportRoot to reset the root ArticulationBody's position and rotation
        Vector3 Tpos = initialRobotPosition + Vector3.up * 0.1f;
        Quaternion Trot = Quaternion.AngleAxis(30, Vector3.up);
        rootArticulationBody.TeleportRoot(Tpos, Trot);
    }

    void Update()
    {
        // Example key press to reset the robot
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetToInitialState();
        }
    }
}
