using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class StopActionGoal : ActionGoal<StopGoal>
    {
        public const string k_RosMessageName = "franka_gripper/StopActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public StopActionGoal() : base()
        {
            this.goal = new StopGoal();
        }

        public StopActionGoal(HeaderMsg header, GoalIDMsg goal_id, StopGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static StopActionGoal Deserialize(MessageDeserializer deserializer) => new StopActionGoal(deserializer);

        StopActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = StopGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
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
