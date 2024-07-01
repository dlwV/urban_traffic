# Unity Traffic Light Simulator

!Traffic Light Simulator

## Description

This project was developed as a final diploma work to obtain a bachelor’s degree. The software is provided "as is", without warranty of any kind, express or implied, including but not limited to the warranties of merchantability, fitness for a particular purpose and noninfringement. In no event shall the authors or copyright holders be liable for any claim, damages or other liability, whether in an action of contract, tort or otherwise, arising from, out of or in connection with the software or the use or other dealings in the software.
**This repository contains a Unity project that models a 3D intersection scene with cars moving according to traffic light signals.**

![Project](https://github.com/dlwV/urban_traffic/assets/76785121/82359cbf-c40c-4691-bc04-d7adbba94d68)

## Features

- 3D model of an intersection with cars and traffic lights.
All models used in the project were taken from the Unity Asset Store package called SimplePoly City. Road and curb textures were used to create lane markings on the road. These objects were grouped into a parent object and duplicated to simulate cross traffic. Prefabs were created from the traffic light and car models, and scripts were added to them in the future.

- Scripts that simulate car behavior and traffic light control.
After writing scripts for the traffic lights and car movement, additional scripts were developed to ensure proper intersection traversal using triggers. These scripts set the car’s Final position coordinates for the MoveTowards function.

1. Stopping the car at the stop line on red traffic lights was implemented.
![StopLine](https://github.com/dlwV/urban_traffic/assets/76785121/6d4f1f2d-db38-4aa6-9b64-80beff08c565)

2. Next, a right turn was implemented using triggers.
![TurnRight](https://github.com/dlwV/urban_traffic/assets/76785121/1ef92c27-c4e0-4149-a134-e8c8c013750d)

3. Left turns were then handled, involving three trigger groups for setting Final positions and an additional group for checking oncoming traffic.
![TurnLeft](https://github.com/dlwV/urban_traffic/assets/76785121/85b305c7-2432-4a81-b250-407d8d29ef6b)

4. Triggers were placed to remove cars after crossing the intersection or exiting the traffic area.
![DeleteCar](https://github.com/dlwV/urban_traffic/assets/76785121/789f8016-2f08-4e2e-9554-49bc75004399)

5. Finally, a script was written to regularly spawn new cars at random positions.
![Generations](https://github.com/dlwV/urban_traffic/assets/76785121/d4a9ddf0-5a51-4661-bba1-7dd9513f5e11)

- User interface (Canvas) for viewing the scene and displaying the average time spent by a car at the intersection.
A custom user interface was created, allowing users to set time values for each traffic light color separately. These values determine how long each color will be active for traffic lights controlling horizontal and vertical movement. Changes take effect after pressing a button, which results in displaying the average time the car spends not at maximum speed in the lower right corner of the screen. Below this value, the difference from the average car travel time in the previous iteration is shown, and the display color changes either to red or green based on this value.
![Project](https://github.com/dlwV/urban_traffic/assets/76785121/82359cbf-c40c-4691-bc04-d7adbba94d68)

## Project Setup

1. Download the project and open it in Unity.
2. Run the scene  `Assets/Scenes/SampleScene.unity`.

## Used Resources

- Unity Asset Store

## Author

- dlwV
