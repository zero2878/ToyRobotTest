using ToyRobotTest.Behavior;
using ToyRobotTest.Robot.Interface;
using ToyRobotTest.Board.Interface;
using ToyRobotTest.Checker.Interface;
using ToyRobotTest.Checker;

namespace ToyRobotTest
{
    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var stopApplication = false;
            var exitCommand = false;
            var description = @"  Instructions:
    1:  Place the toy on a your customized grid 
        using the following command:

        PLACE X,Y,F (Where X and Y are integers and F  
        must be either NORTH, SOUTH, EAST or WEST)

    2:  When the toy is placed, have at go at using
        the following commands.
        
        REPORT – Shows the current status of the robot. 
        LEFT   – turns the robot 90 degrees left.
        RIGHT  – turns the robot 90 degrees right.
        MOVE   – Moves the robot 1 unit in the facing direction.
        RESET  - Reset the board dimension and the robot location.
        EXIT   – Closes the robot simulator.\n";
            Console.WriteLine("Welcome to My Toy Robot");
            Console.WriteLine("==============================================");
            Console.WriteLine(description);
            Console.WriteLine("==============================================");
            Console.WriteLine("\nBefore we start let us set the board first");
            do {
                exitCommand = false;
                Console.Write("Enter Board Length: ");
                int length = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Board Width: ");
                int width = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine("Now that our Board is set let's set your robot initial position");
                Console.WriteLine();
                Console.WriteLine("Type the command PLACE X,Y,F and replace the value of X and Y with the coordinate in the board");
                Console.WriteLine("and F with NORTH,SOUTH,EAST,WEST");
                IBoard squareBoard = new Board.Board(width, length);
                IInputParser inputParser = new InputParser();
                IRobot robot = new Robot.Robot();
                var simulator = new Behaviour(robot, squareBoard, inputParser);
                do
                {
                    Console.Write("Your Command: ");
                    var command = Console.ReadLine();
                    if (command == null) continue;

                    if (command.Equals("EXIT"))
                    {
                        exitCommand = true;
                        stopApplication = true;
                    }
                    else if (command.Equals("RESET"))
                    {
                        Console.WriteLine("\nLet us reset the board and your robot.");
                        exitCommand = true;
                    }
                    else
                    {
                        try
                        {
                            var output = simulator.ProcessCommand(command.Split(' '));
                            if (!string.IsNullOrEmpty(output))
                                Console.WriteLine(output);
                        }
                        catch (ArgumentException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                } while (!exitCommand);
            }
            while (!stopApplication);
        }
    }
}