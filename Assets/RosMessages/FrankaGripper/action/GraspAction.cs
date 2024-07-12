using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.FrankaGripper
{
    public class GraspAction : Action<GraspActionGoal, GraspActionResult, GraspActionFeedback, GraspGoal, GraspResult, GraspFeedback>
    {
        public const string k_RosMessageName = "franka_gripper/GraspAction";
        public override string RosMessageName => k_RosMessageName;


        public GraspAction() : base()
        {
            this.action_goal = new GraspActionGoal();
            this.action_result = new GraspActionResult();
            this.action_feedback = new GraspActionFeedback();
        }

        public static GraspAction Deserialize(MessageDeserializer deserializer) => new GraspAction(deserializer);

        GraspAction(MessageDeserializer deserializer)
        {
            this.action_goal = GraspActionGoal.Deserialize(deserializer);
            this.action_result = GraspActionResult.Deserialize(deserializer);
            this.action_feedback = GraspActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
