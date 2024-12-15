using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class GraspActionFeedback : ActionFeedback<GraspFeedback>
    {
        public const string k_RosMessageName = "franka_gripper/GraspActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public GraspActionFeedback() : base()
        {
            this.feedback = new GraspFeedback();
        }

        public GraspActionFeedback(HeaderMsg header, GoalStatusMsg status, GraspFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static GraspActionFeedback Deserialize(MessageDeserializer deserializer) => new GraspActionFeedback(deserializer);

        GraspActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = GraspFeedback.Deserialize(deserializer);
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
