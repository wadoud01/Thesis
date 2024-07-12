using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.FrankaGripper
{
    public class GraspActionGoal : ActionGoal<GraspGoal>
    {
        public const string k_RosMessageName = "franka_gripper/GraspActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public GraspActionGoal() : base()
        {
            this.goal = new GraspGoal();
        }

        public GraspActionGoal(HeaderMsg header, GoalIDMsg goal_id, GraspGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static GraspActionGoal Deserialize(MessageDeserializer deserializer) => new GraspActionGoal(deserializer);

        GraspActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = GraspGoal.Deserialize(deserializer);
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
