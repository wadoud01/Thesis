using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;


namespace RosMessageTypes.FrankaGripper
{
    public class StopAction : Action<StopActionGoal, StopActionResult, StopActionFeedback, StopGoal, StopResult, StopFeedback>
    {
        public const string k_RosMessageName = "franka_gripper/StopAction";
        public override string RosMessageName => k_RosMessageName;


        public StopAction() : base()
        {
            this.action_goal = new StopActionGoal();
            this.action_result = new StopActionResult();
            this.action_feedback = new StopActionFeedback();
        }

        public static StopAction Deserialize(MessageDeserializer deserializer) => new StopAction(deserializer);

        StopAction(MessageDeserializer deserializer)
        {
            this.action_goal = StopActionGoal.Deserialize(deserializer);
            this.action_result = StopActionResult.Deserialize(deserializer);
            this.action_feedback = StopActionFeedback.Deserialize(deserializer);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.action_goal);
            serializer.Write(this.action_result);
            serializer.Write(this.action_feedback);
        }

    }
}
