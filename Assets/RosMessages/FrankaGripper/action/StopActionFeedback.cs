using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class StopActionFeedback : ActionFeedback<StopFeedback>
    {
        public const string k_RosMessageName = "franka_gripper/StopActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public StopActionFeedback() : base()
        {
            this.feedback = new StopFeedback();
        }

        public StopActionFeedback(HeaderMsg header, GoalStatusMsg status, StopFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static StopActionFeedback Deserialize(MessageDeserializer deserializer) => new StopActionFeedback(deserializer);

        StopActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = StopFeedback.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.feedback);
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
