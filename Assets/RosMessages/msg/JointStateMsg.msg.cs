using System;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Sensor
{
    public class JointStateMsg : Message
    {
        public const string RosMessageName = "sensor_msgs/JointState";

        // Fields
        public HeaderMsg header;
        public string[] name;
        public float[] position;
        public float[] velocity;
        public float[] effort;

        // Default constructor
        public JointStateMsg()
        {
            this.header = new HeaderMsg();
            this.name = new string[0];
            this.position = new float[0];
            this.velocity = new float[0];
            this.effort = new float[0];
        }

        // Constructor with parameters
        public JointStateMsg(HeaderMsg header, string[] name, float[] position, float[] velocity, float[] effort)
        {
            this.header = header;
            this.name = name;
            this.position = position;
            this.velocity = velocity;
            this.effort = effort;
        }
    }

    public class HeaderMsg : Message
    {
        public const string RosMessageName = "std_msgs/Header";

        // Fields
        public uint seq;
        public TimeMsg stamp;
        public string frame_id;

        // Default constructor
        public HeaderMsg()
        {
            this.seq = 0;
            this.stamp = new TimeMsg();
            this.frame_id = "";
        }

        // Constructor with parameters
        public HeaderMsg(uint seq, TimeMsg stamp, string frame_id)
        {
            this.seq = seq;
            this.stamp = stamp;
            this.frame_id = frame_id;
        }
    }

    public class TimeMsg : Message
    {
        public const string RosMessageName = "std_msgs/Time";

        // Fields
        public uint secs;
        public uint nsecs;

        // Default constructor
        public TimeMsg()
        {
            this.secs = 0;
            this.nsecs = 0;
        }

        // Constructor with parameters
        public TimeMsg(uint secs, uint nsecs)
        {
            this.secs = secs;
            this.nsecs = nsecs;
        }
    }
}
