# **Franka Panda Robot Control Based on Augmented Reality**  
This repository contains the implementation of a control system for the **Franka Emika Panda robotic arm**, utilizing **Augmented Reality (AR)** interfaces and Human-Robot Interaction (HRI). The system integrates ROS, MoveIt, Unity3D, and Hololens 2 to achieve real-time robot control and user interaction.

---

## **Table of Contents**  
1. [Project Overview](#project-overview)  
2. [System Components](#system-components)  
3. [Features](#features)  
4. [Setup Instructions](#setup-instructions)  
5. [Usage Guide](#usage-guide)  
6. [Demonstration](#demonstration)  
7. [Results and Outcomes](#results-and-outcomes)  


---

## **1. Project Overview**  
This project presents an AR-based control system for the **Franka Panda robotic arm**, combining **robotic simulation** and **augmented reality** to improve usability and interaction:  

- **User Interface:** Designed in Unity3D and displayed on Hololens 2 using MRTK.  
- **Robot Control:** ROS and MoveIt are used for real-time motion planning.  
- **Synchronization:** A ROS-TCP communication protocol enables data transfer between ROS and Unity.
- **Real-Time Data Transformation:** The Data are transformed using UDP protocol to another PC which is connected to the real robot, waiting for the user permission in order to be moved.   

The system allows the user to move the robot using sliders, or a sphere which represents the desired point to be reached, receiving immediate feedback through an AR-based interface.


## Important Note:

The holographic robot is perfectly aligned in size and position with the real robot. However, due to the recording limitations of the Hololens 2, videos may appear to show a misalignment or scale difference between the hologram and the physical robot. This is an artifact of the recording process, and in real-time, the hologram and robot are accurately overlapped.


<p align="center">
<img src="docs/User_Holo.gif" alt="Demo of the system" width="200"><img src="docs/Holo_Screen.gif" alt="Demo of the system" width="628">
</p>

---

## **2. System Components**  
The system architecture includes the following key components:  

1. **Robot Simulation and Control (ROS):**
The repository to the ROS files used : https://github.com/wadoud01/Thesis-ROS
   - Motion planning using MoveIt.
   - Feedback robot state publisher.
   - cordinations sender to real robot using UDP to ensures synchronization between ROS (backend) and Unity (frontend).  

2. **Augmented Reality Interface (Unity3D + Hololens 2):**  
   - Buttons: "Move Hologram," "Grasp," and "Move Real Robot."  
   - Sliders: Control the X, Y, Z positions in 3D space.
   - Sphere (Can be freely placed in space.)
   - Sliders - Sphere syncronization : The sliders flows the sphere values and vice-versa!
   - Feedback Panel: Displays system status and robot responses.
   - Moveing out of the Work-space alert: Once the user places the sphere out the workspace the robot will signal indicating the user to go back inside the possible range. 

3. **Semi-open loop Real Franka robot control:**  
   - A simple code that receives the desired joint states coordination from ROS and move the Real-Franka robot to the desired postion, allwoing the possiblity to control all the joints of the Franka-Robot including also the gripper to maintain opening & closing operation!
   - The repository of the code could be found here: 

---

## **3. Features**  
- **AR-Based Interaction:**  
  Users control the robot through intuitive AR sliders and sphere in real time.  

- **Real-Time Feedback:** 
  Immediate updates on robot status are displayed on the AR interface.  

- **Seamless Synchronization:**  
  ROS-TCP ensures continuous communication between Unity and ROS.  

- **Path Planning with MoveIt:**  
  Safe and accurate robot motion planning.  

---

## **4. Setup Instructions**  

### **Prerequisites**  
- **Operating System:** Ubuntu 20.04 (ROS Noetic compatible)  
- **Software:**  
   - ROS Noetic installed  
   - Unity3D (2021.x or higher)  
   - MRTK Toolkit for Hololens 2  
   - Python 3.x  

---
## **5. Usage Guide**  
This section explains how to use the AR-based control system to interact with the Franka Emika Panda robot.  

### **System Workflow**  
1. **Launch the ROS Environment:**  
   Start the necessary ROS nodes:  
   ```bash
   roslaunch panda_moveit_config demo.launch

2. Deploy the Unity AR Interface:

   1. Open the Unity project provided in the repository.
   Deploy the AR application to the Hololens 2 device.
   AR-Based Interaction:

   2. Wear the Hololens 2 and interact with the virtual interface:
   Sliders: Adjust X, Y, Z values to define the target position in space.
   Buttons:
   Move Hologram: Simulates the robot's motion in AR.
   Grasp: Commands the robot to perform a grasping action.
   Move Real Robot: Moves the physical robot to the defined position.

   3. Feedback Panel:
   View real-time status updates (e.g., "Moving...," "Coordinations (X, Y, Z) sent " "Gripper closed") on the AR text panel.

---

### **6. Workflow Overview**  
1. **Setup and Initialization:**  
   - ROS nodes are launched to control the Panda robot.  
   - Unity AR application is deployed to the **Hololens 2**.  

2. **User Interaction via AR Interface:**  
   - Adjust the **X, Y, Z sliders** to define target points in space.  
   - Use the interface buttons to simulate and command robot actions:  
     - **Move Hologram:** Visualize the robot's motion in AR.  
     - **Grasp:** Perform grasping actions with the robotic arm.  
     - **Move Real Robot:** Move the physical Panda robot to the selected target.  

3. **Task Execution:**  
   - Users completed the task of grasping a sponge and placing it at a desired location.  
   - Real-time feedback was provided via the AR interface.  

---

### **Screenshots**  

#### **AR Interface: Buttons and Sliders**  
The AR interface consists of control buttons, sliders for spatial inputs, and a feedback text panel.  

<img src="docs/ar_interface.png" alt="AR_interface" width="300px">


#### **Hologram Simulation**  
The robot's motion is visualized as a hologram in the AR environment before executing on the real robot.

#### **Physical Robot Execution**  
The Franka Panda robot successfully moves to the target position.

<p align="center">
<img src="docs/Holo_Vision.gif" alt="Demo of the system" width="535"><img src="docs/Rea_Robot1.gif" alt="Demo of the system" width="170">
</p>

---

### **Performance Highlights**  
- **Task Success:** Users were able to complete grasping tasks with high precision.  
- **Synchronization:** The UDP-based communication ensured accurate coordination between the AR simulation and real-world execution.  
- **User Feedback:** Real-time updates, such as "Goal Reached" or "IK Solving," were displayed to guide the user effectively.  

---

### **Key Takeaways**  
This demonstration validates the usability and functionality of the AR-based robotic control system:  
- Users experienced intuitive robot manipulation using AR controls.  
- The system bridges the gap between **virtual interaction** and **physical execution**.  
- Smooth task execution demonstrates the reliability of the system integration (ROS, Unity, and MoveIt).  

---

### **Future Enhancements for Demonstration**  
To further improve the demonstration experience:  
- Include multi-camera video recordings of both AR visuals and the physical robot.  
- Integrate gesture-based controls to complement button-based input.  
- Add task-specific metrics like completion time and accuracy for detailed analysis.  

---
## **7. Evaluation and Feedback**

### **User Evaluation Process**
To assess the usability and performance of the AR-based control system, we conducted user trials where participants completed the task of **grasping a sponge** and **moving it to a target location** using the Hololens 2 interface.

---

### **Evaluation Methods**
We utilized two standardized evaluation methods:

1. **System Usability Scale (SUS)**  
   - The SUS questionnaire was used to evaluate the overall usability of the system.  
   - The SUS score provides a quantitative measure of how intuitive and user-friendly the AR interface and robotic control system are.

2. **NASA Task Load Index (NASA-TLX)**  
   - NASA-TLX was applied to assess the workload experienced by users during the task.  
   - This method evaluates six key dimensions:  
     - **Mental Demand**  
     - **Physical Demand**  
     - **Temporal Demand**  
     - **Performance**  
     - **Effort**  
     - **Frustration**  

---

### **User Feedback Collection**

- **Participants**: Users of varying technical backgrounds participated in the experiment.  
- **Task**:  
   - Grasp a sponge using the AR interface.  
   - Move the Franka Panda robotic arm to place the sponge in a target position.  
- **Feedback Mechanism**:  
   - Post-task **SUS questionnaire** to collect usability feedback.  
   - Post-task **NASA-TLX survey** to understand workload.  
   - Open-ended questions for additional comments and suggestions.

---
### **Conclusion of Evaluation**
The evaluation results show that:  
1. The system is **highly usable** with an **SUS score of 88**.  
2. The **workload** is well-balanced, with low physical demand and frustration.  
3. Users were satisfied with the real-time feedback and intuitive AR interface, ensuring smooth and precise robot manipulation.

## Author  
**Wadoud Guelmami**  

