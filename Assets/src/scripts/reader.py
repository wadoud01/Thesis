#!/usr/bin/env python

import rospy
from sensor_msgs.msg import JointState

def joint_states_callback(msg):
    rounded_positions = [round(pos, 2) for pos in msg.position]
    rounded_velocities = [round(vel, 2) for vel in msg.velocity]
    rounded_efforts = [round(eff, 2) for eff in msg.effort]

    joint_info = []

    for i in range(len(msg.name)):
        joint_info.append(f'Joint {i + 1} = [Name: {msg.name[i]}, Position: {rounded_positions[i]}, Velocity: {rounded_velocities[i]}, Effort: {rounded_efforts[i]}]')

    print("joints = [")
    for joint in joint_info:
        print(f'  "{joint}"')
    print("]")

    # Shutdown the node after displaying the message once
    rospy.signal_shutdown('Displayed joint states once.')

def joint_state_listener():
    rospy.init_node('joint_state_listener', anonymous=True)
    rospy.Subscriber("/joint_states", JointState, joint_states_callback)
    rospy.spin()

if __name__ == '__main__':
    try:
        joint_state_listener()
    except rospy.ROSInterruptException:
        pass

