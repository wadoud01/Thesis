//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Franka
{
    [Serializable]
    public class SetJointConfigurationResponse : Message
    {
        public const string k_RosMessageName = "franka_msgs/SetJointConfiguration";
        public override string RosMessageName => k_RosMessageName;

        public bool success;
        public string error;

        public SetJointConfigurationResponse()
        {
            this.success = false;
            this.error = "";
        }

        public SetJointConfigurationResponse(bool success, string error)
        {
            this.success = success;
            this.error = error;
        }

        public static SetJointConfigurationResponse Deserialize(MessageDeserializer deserializer) => new SetJointConfigurationResponse(deserializer);

        private SetJointConfigurationResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.success);
            deserializer.Read(out this.error);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.success);
            serializer.Write(this.error);
        }

        public override string ToString()
        {
            return "SetJointConfigurationResponse: " +
            "\nsuccess: " + success.ToString() +
            "\nerror: " + error.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize, MessageSubtopic.Response);
        }
    }
}
