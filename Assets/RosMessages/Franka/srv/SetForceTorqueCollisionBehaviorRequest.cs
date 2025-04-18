//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Franka
{
    [Serializable]
    public class SetForceTorqueCollisionBehaviorRequest : Message
    {
        public const string k_RosMessageName = "franka_msgs/SetForceTorqueCollisionBehavior";
        public override string RosMessageName => k_RosMessageName;

        public double[] lower_torque_thresholds_nominal;
        public double[] upper_torque_thresholds_nominal;
        public double[] lower_force_thresholds_nominal;
        public double[] upper_force_thresholds_nominal;

        public SetForceTorqueCollisionBehaviorRequest()
        {
            this.lower_torque_thresholds_nominal = new double[7];
            this.upper_torque_thresholds_nominal = new double[7];
            this.lower_force_thresholds_nominal = new double[6];
            this.upper_force_thresholds_nominal = new double[6];
        }

        public SetForceTorqueCollisionBehaviorRequest(double[] lower_torque_thresholds_nominal, double[] upper_torque_thresholds_nominal, double[] lower_force_thresholds_nominal, double[] upper_force_thresholds_nominal)
        {
            this.lower_torque_thresholds_nominal = lower_torque_thresholds_nominal;
            this.upper_torque_thresholds_nominal = upper_torque_thresholds_nominal;
            this.lower_force_thresholds_nominal = lower_force_thresholds_nominal;
            this.upper_force_thresholds_nominal = upper_force_thresholds_nominal;
        }

        public static SetForceTorqueCollisionBehaviorRequest Deserialize(MessageDeserializer deserializer) => new SetForceTorqueCollisionBehaviorRequest(deserializer);

        private SetForceTorqueCollisionBehaviorRequest(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.lower_torque_thresholds_nominal, sizeof(double), 7);
            deserializer.Read(out this.upper_torque_thresholds_nominal, sizeof(double), 7);
            deserializer.Read(out this.lower_force_thresholds_nominal, sizeof(double), 6);
            deserializer.Read(out this.upper_force_thresholds_nominal, sizeof(double), 6);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.lower_torque_thresholds_nominal);
            serializer.Write(this.upper_torque_thresholds_nominal);
            serializer.Write(this.lower_force_thresholds_nominal);
            serializer.Write(this.upper_force_thresholds_nominal);
        }

        public override string ToString()
        {
            return "SetForceTorqueCollisionBehaviorRequest: " +
            "\nlower_torque_thresholds_nominal: " + System.String.Join(", ", lower_torque_thresholds_nominal.ToList()) +
            "\nupper_torque_thresholds_nominal: " + System.String.Join(", ", upper_torque_thresholds_nominal.ToList()) +
            "\nlower_force_thresholds_nominal: " + System.String.Join(", ", lower_force_thresholds_nominal.ToList()) +
            "\nupper_force_thresholds_nominal: " + System.String.Join(", ", upper_force_thresholds_nominal.ToList());
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
