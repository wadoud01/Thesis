using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class StopActionResult : ActionResult<StopResult>
    {
        public const string k_RosMessageName = "franka_gripper/StopActionResult";
        public override string RosMessageName => k_RosMessageName;


        public StopActionResult() : base()
        {
            this.result = new StopResult();
        }

        public StopActionResult(HeaderMsg header, GoalStatusMsg status, StopResult result) : base(header, status)
        {
            this.result = result;
        }
        public static StopActionResult Deserialize(MessageDeserializer deserializer) => new StopActionResult(deserializer);

        StopActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = StopResult.Deserialize(deserializer);
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
