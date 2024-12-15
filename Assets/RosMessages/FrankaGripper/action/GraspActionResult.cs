using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class GraspActionResult : ActionResult<GraspResult>
    {
        public const string k_RosMessageName = "franka_gripper/GraspActionResult";
        public override string RosMessageName => k_RosMessageName;


        public GraspActionResult() : base()
        {
            this.result = new GraspResult();
        }

        public GraspActionResult(HeaderMsg header, GoalStatusMsg status, GraspResult result) : base(header, status)
        {
            this.result = result;
        }
        public static GraspActionResult Deserialize(MessageDeserializer deserializer) => new GraspActionResult(deserializer);

        GraspActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = GraspResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.result);
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
