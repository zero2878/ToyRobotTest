using ToyRobotTest.Robot.Enum;
using ToyRobotTest.Board.Interface;
using ToyRobotTest.Robot.Interface;
using ToyRobotTest.Checker.Interface;

namespace ToyRobotTest.Behavior
{
    public class Behaviour
    {
        public IRobot Robot { get; private set; }
        public IBoard SquareBoard { get; private set; }
        public IInputParser InputParser { get; private set; }

        public Behaviour(IRobot robot, IBoard squareBoard, IInputParser inputParser)
        {
            Robot = robot;
            SquareBoard = squareBoard;
            InputParser = inputParser;
        }

        public string ProcessCommand(string[] input)
        {
            var returnmessage = "";
            var command = InputParser.ParseCommand(input);
            if (command != Command.Place && Robot.Position == null) return "\nYour Robot is not yet placed in the board.\nPlease place your Robot in the location you wanted.";

            switch (command)
            {
                case Command.Place:
                    var placeCommandParameter = InputParser.ParseCommandParameter(input);
                    if (SquareBoard.IsValidPosition(placeCommandParameter.Position))
                        Robot.Place(placeCommandParameter.Position, placeCommandParameter.Direction);
                    else
                        returnmessage = "\nSorry you are placing your robot beyond your board.";
                    break;
                case Command.Move:
                    var newPosition = Robot.GetNextPosition();
                    if (SquareBoard.IsValidPosition(newPosition))
                        Robot.Position = newPosition;
                    else
                        returnmessage = $"\nSorry you cannot move further you are already at the edge of the board\n{GetReport()}";
                    break;
                case Command.Left:
                    Robot.RotateLeft();
                    break;
                case Command.Right:
                    Robot.RotateRight();
                    break;
                case Command.Report:
                    return GetReport();
            }
            return returnmessage;
        }

        public string GetReport()
        {
            return string.Format("\nRobot Location: {0},{1},{2}", Robot.Position.X,
                Robot.Position.Y, Robot.Direction.ToString().ToUpper());
        }
    }
}
