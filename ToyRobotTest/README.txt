Toy Robot Test

Programming language used is C#, with 2 simple projects(ToyRobotTest and ToyRobotTest.Test) in 1 solution.

Requirements
- You are required to simulate a toy robot moving on a square tabletop, of dimensions 5 units x 5 units.
- There are no other obstructions on the table surface. The robot is free to roam around the surface of the table, but must be prevented from falling to destruction.
- Any movement that would result in the robot falling from the table must be prevented, however further valid movement commands must still be allowed.
- All commands should be discarded until a valid place command has been executed.
- The solution must be written in C#.
- The UI can be provided via CLI, however you are free to expand on this.
- We want to see what you can do, please put your best foot forward when architecting a solution and treat it as a project given to you by the client.
- Give some consideration to testing.
- Include a README file with instructions on how to build/compile your solution and how to run it. Additionally, please mention any assumptions you've made.
- Share your code via a public GitHub repository, git bundle or zip file.

Commands
- PLACE X,Y,DIRECTION
	X and Y are integers that indicate a location on the tabletop.
	DIRECTION is a string indicating which direction the robot should face. It it one of the four cardinal directions: NORTH, EAST, SOUTH or WEST.
- MOVE
	Instructs the robot to move 1 square in the direction it is facing.
- LEFT
	Instructs the robot to rotate 90° anticlockwise/counterclockwise.
- RIGHT
	Instructs the robot to rotate 90° clockwise.
- REPORT
	Outputs the robot's current location on the tabletop and the direction it is facing.
- RESET
	Reset the board dimension and robot location
- EXIT
	Closes the application

