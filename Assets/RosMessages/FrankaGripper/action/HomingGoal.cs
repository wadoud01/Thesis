//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.FrankaGripper
{
    [Serializable]
    public class HomingGoal : Message
    {
        public const string k_RosMessageName = "franka_gripper/Homing";
        public override string RosMessageName => k_RosMessageName;


        public HomingGoal()
        {
        }
        public static HomingGoal Deserialize(MessageDeserializer deserializer) => new HomingGoal(deserializer);

        private HomingGoal(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "HomingGoal: ";
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Goal);
        }
    }
}