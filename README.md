# JointStateSubscriber

## Overview
The `JointStateSubscriber` script in Unity subscribes to joint state messages from a ROS network. It updates Unity ArticulationBody components to match joint positions received from the specified ROS topic.

## Issue Description
When attempting to run the script, the following error occurs:
This error suggests a mismatch between the number of joints reported in the ROS message and the number of ArticulationBody components in Unity.

## Code Explanation

### JointStateSubscriber.cs
```csharp
using UnityEngine;
using RosMessageTypes.Sensor;
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using System.Collections.Generic;

public class JointStateSubscriber : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "/joint_states";
    public GameObject robot;
    private ArticulationBody[] jointArticulationBodies;

    void Start()
    {
        ros = ROSConnection.instance;
        ros.Subscribe<JointStateMsg>(topicName, UpdateJointStates);

        // Initialize the joints
        jointArticulationBodies = robot.GetComponentsInChildren<ArticulationBody>();
    }

    void UpdateJointStates(JointStateMsg jointStateMessage)
    {
        // Ensure the number of joints in the message matches the robot's joints
        if (jointStateMessage.position.Length != jointArticulationBodies.Length)
        {
            Debug.LogError("Joint state message length does not match the number of robot joints.");
            return;
        }

        // Update each joint's target position
        for (int i = 0; i < jointArticulationBodies.Length; i++)
        {
            var jointDrive = jointArticulationBodies[i].xDrive;
            jointDrive.target = (float)(jointStateMessage.position[i] * Mathf.Rad2Deg); // Convert from radians to degrees
            jointArticulationBodies[i].xDrive = jointDrive;
        }
    }
}


/////////////////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////////

// JointStateMsg.cs looks like:

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;

namespace RosMessageTypes.Sensor
{
    [Serializable]
    public class JointStateMsg : Message
    {
        public const string k_RosMessageName = "sensor_msgs/JointState";
        public override string RosMessageName => k_RosMessageName;

        public HeaderMsg header;
        public string[] name;
        public double[] position;
        public double[] velocity;
        public double[] effort;

        public JointStateMsg()
        {
            this.header = new HeaderMsg();
            this.name = new string[0];
            this.position = new double[0];
            this.velocity = new double[0];
            this.effort = new double[0];
        }

        public JointStateMsg(HeaderMsg header, string[] name, double[] position, double[] velocity, double[] effort)
        {
            this.header = header;
            this.name = name;
            this.position = position;
            this.velocity = velocity;
            this.effort = effort;
        }

        public static JointStateMsg Deserialize(MessageDeserializer deserializer) => new JointStateMsg(deserializer);

        private JointStateMsg(MessageDeserializer deserializer)
        {
            this.header = HeaderMsg.Deserialize(deserializer);
            deserializer.Read(out this.name, deserializer.ReadLength());
            deserializer.Read(out this.position, sizeof(double), deserializer.ReadLength());
            deserializer.Read(out this.velocity, sizeof(double), deserializer.ReadLength());
            deserializer.Read(out this.effort, sizeof(double), deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.WriteLength(this.name);
            serializer.Write(this.name);
            serializer.WriteLength(this.position);
            serializer.Write(this.position);
            serializer.WriteLength(this.velocity);
            serializer.Write(this.velocity);
            serializer.WriteLength(this.effort);
            serializer.Write(this.effort);
        }

        public override string ToString()
        {
            return "JointStateMsg: " +
            "\nheader: " + header.ToString() +
            "\nname: " + System.String.Join(", ", name.ToList()) +
            "\nposition: " + System.String.Join(", ", position.ToList()) +
            "\nvelocity: " + System.String.Join(", ", velocity.ToList()) +
            "\neffort: " + System.String.Join(", ", effort.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}

//////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////////////

** this is what rostopic echo ./joint_states gave me when I run Panda robot on ROS:
  - panda_joint1
  - panda_joint2
  - panda_joint3
  - panda_joint4
  - panda_joint5
  - panda_joint6
  - panda_joint7
  - panda_finger_joint1
  - panda_finger_joint2
position: [-0.0015821584717166104, -0.7943869903723391, 0.0012281290466464867, -2.3638982697954374, 0.0006501100753908418, 1.5828537411713262, 0.7846784180658801, 0.0009995241610755343, 0.0009995241610755343]
velocity: [0.0035677726280856407, 0.000822763804113286, -0.0063275332532466595, 0.00279297697337853, -0.005301808906914612, -0.0056556699105319574, -0.0026148669173828316, 8.717624400309522e-05, 8.717624400309522e-05]
effort: [-0.057221632978472096, 3.7724317682463404, 0.6342069921164082, -22.095580280396128, -0.660068477303177, -2.326199971163367, 0.04994594295633568, -1.721518465797584e-05, -1.721518465797584e-05]
