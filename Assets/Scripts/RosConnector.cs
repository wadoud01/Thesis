using System.Collections;
using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector;
using UnityEngine;

public class RosConnector : MonoBehaviour
{
    // ROS Connector
    ROSConnection m_Ros;

    // Start is called before the first frame update
    void Start()
    {
        // Get ROS connection static instance
        m_Ros = ROSConnection.GetOrCreateInstance();
    }

    // Update is called once per frame
    void Update()
    {

    }
}