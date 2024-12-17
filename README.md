# **Control of the Franka Panda Robot Based on Augmented Reality**  
This repository contains the implementation of a control system for the **Franka Emika Panda robotic arm**, utilizing **Augmented Reality (AR)** interfaces and Human-Robot Interaction (HRI). The system integrates ROS, MoveIt, Unity3D, and Hololens 2 to achieve real-time robot control and user interaction.

---

## **Table of Contents**  
1. [Project Overview](#project-overview)  
2. [System Components](#system-components)  
3. [Features](#features)  
4. [Technologies Used](#technologies-used)  
5. [Setup Instructions](#setup-instructions)  
6. [Usage Guide](#usage-guide)  
7. [Demonstration](#demonstration)  
8. [Results and Outcomes](#results-and-outcomes)  
9. [Future Work](#future-work)  
10. [Acknowledgments](#acknowledgments)  
11. [Contact](#contact)  

---

## **1. Project Overview**  
This project presents an AR-based control system for the **Franka Panda robotic arm**, combining **robotic simulation** and **augmented reality** to improve usability and interaction:  

- **User Interface:** Designed in Unity3D and displayed on Hololens 2 using MRTK.  
- **Robot Control:** ROS and MoveIt are used for real-time motion planning.  
- **Synchronization:** A UDP-based communication protocol enables data transfer between ROS and Unity.  

The system allows the user to move the robot using AR buttons and sliders, receiving immediate feedback through an AR-based interface.

---

## **2. System Components**  
The system architecture includes the following key components:  

1. **Robot Simulation and Control (ROS):**  
   - Real-time control and motion planning using MoveIt.  
   - URDF model of the Franka Panda robot.  

2. **Augmented Reality Interface (Unity3D + Hololens 2):**  
   - Buttons: "Move Hologram," "Grasp," and "Move Real Robot."  
   - Sliders: Control the X, Y, Z positions in 3D space.  
   - Feedback Panel: Displays system status and robot responses.  

3. **Communication Protocol (UDP):**  
   - Ensures synchronization between ROS (backend) and Unity (frontend).  

---

## **3. Features**  
- **AR-Based Interaction:**  
  Users control the robot through intuitive AR sliders and buttons in real time.  

- **Real-Time Feedback:**  
  Immediate updates on robot status are displayed on the AR interface.  

- **Seamless Synchronization:**  
  UDP ensures continuous communication between Unity and ROS.  

- **Path Planning with MoveIt:**  
  Safe and accurate robot motion planning.  

---

## **4. Technologies Used**  
- **ROS (Robot Operating System):** Framework for robot control and motion planning.  
- **MoveIt:** Path planning and motion execution for the Panda robot.  
- **Unity3D + MRTK:** AR development for Hololens 2.  
- **UDP Communication:** Real-time synchronization between Unity and ROS.  
- **Franka Emika Panda:** Robotic arm used for the project.  

---

## **5. Setup Instructions**  

### **Prerequisites**  
- **Operating System:** Ubuntu 20.04 (ROS Noetic compatible)  
- **Software:**  
   - ROS Noetic installed  
   - Unity3D (2021.x or higher)  
   - MRTK Toolkit for Hololens 2  
   - Python 3.x  

---

### **Installation Steps**  

1. **Clone the Repository:**  
   ```bash
   git clone https://github.com/yourusername/franka_panda_ar_control.git
   cd franka_panda_ar_control
# **Control of the Franka Panda Robot Based on Augmented Reality**  
This repository contains the implementation of a control system for the **Franka Emika Panda robotic arm**, utilizing **Augmented Reality (AR)** interfaces and Human-Robot Interaction (HRI). The system integrates ROS, MoveIt, Unity3D, and Hololens 2 to achieve real-time robot control and user interaction.

---

## **Table of Contents**  
1. [Project Overview](#project-overview)  
2. [System Components](#system-components)  
3. [Features](#features)  
4. [Technologies Used](#technologies-used)  
5. [Setup Instructions](#setup-instructions)  
6. [Usage Guide](#usage-guide)  
7. [Demonstration](#demonstration)  
8. [Results and Outcomes](#results-and-outcomes)  
9. [Future Work](#future-work)  
10. [Acknowledgments](#acknowledgments)  
11. [Contact](#contact)  

---

## **1. Project Overview**  
This project presents an AR-based control system for the **Franka Panda robotic arm**, combining **robotic simulation** and **augmented reality** to improve usability and interaction:  

- **User Interface:** Designed in Unity3D and displayed on Hololens 2 using MRTK.  
- **Robot Control:** ROS and MoveIt are used for real-time motion planning.  
- **Synchronization:** A UDP-based communication protocol enables data transfer between ROS and Unity.  

The system allows the user to move the robot using AR buttons and sliders, receiving immediate feedback through an AR-based interface.

---

## **2. System Components**  
The system architecture includes the following key components:  

1. **Robot Simulation and Control (ROS):**  
   - Real-time control and motion planning using MoveIt.  
   - URDF model of the Franka Panda robot.  

2. **Augmented Reality Interface (Unity3D + Hololens 2):**  
   - Buttons: "Move Hologram," "Grasp," and "Move Real Robot."  
   - Sliders: Control the X, Y, Z positions in 3D space.  
   - Feedback Panel: Displays system status and robot responses.  

3. **Communication Protocol (UDP):**  
   - Ensures synchronization between ROS (backend) and Unity (frontend).  

---

## **3. Features**  
- **AR-Based Interaction:**  
  Users control the robot through intuitive AR sliders and buttons in real time.  

- **Real-Time Feedback:**  
  Immediate updates on robot status are displayed on the AR interface.  

- **Seamless Synchronization:**  
  UDP ensures continuous communication between Unity and ROS.  

- **Path Planning with MoveIt:**  
  Safe and accurate robot motion planning.  

---

## **4. Technologies Used**  
- **ROS (Robot Operating System):** Framework for robot control and motion planning.  
- **MoveIt:** Path planning and motion execution for the Panda robot.  
- **Unity3D + MRTK:** AR development for Hololens 2.  
- **UDP Communication:** Real-time synchronization between Unity and ROS.  
- **Franka Emika Panda:** Robotic arm used for the project.  

---

## **5. Setup Instructions**  

### **Prerequisites**  
- **Operating System:** Ubuntu 20.04 (ROS Noetic compatible)  
- **Software:**  
   - ROS Noetic installed  
   - Unity3D (2021.x or higher)  
   - MRTK Toolkit for Hololens 2  
   - Python 3.x  

---

### **Installation Steps**  

1. **Clone the Repository:**  
   ```bash
   git clone https://github.com/yourusername/franka_panda_ar_control.git
   cd franka_panda_ar_control
