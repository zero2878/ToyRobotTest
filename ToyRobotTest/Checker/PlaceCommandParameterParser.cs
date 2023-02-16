using ToyRobotTest.Robot;
using ToyRobotTest.Robot.Enum;

namespace ToyRobotTest.Checker
{
    public class PlaceCommandParameterParser
    {
        private const int ParameterCount = 3;
        private const int CommandInputCount = 2;
        public PlaceCommandParameter ParseParameters(string[] input)
        {
            Direction direction;
            Position position = null;

            if (input.Length != CommandInputCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            var commandParams = input[1].Split(',');
            if (commandParams.Length != ParameterCount)
                throw new ArgumentException("Incomplete command. Please ensure that the PLACE command is using format: PLACE X,Y,F");

            if (!Enum.TryParse(commandParams[commandParams.Length - 1], true, out direction))
                throw new ArgumentException("Invalid direction. Please select from one of the following directions: NORTH|EAST|SOUTH|WEST");

            var x = Convert.ToInt32(commandParams[0]);
            var y = Convert.ToInt32(commandParams[1]);
            position = new Position(x, y);

            return new PlaceCommandParameter(position, direction);
        }
    }
}
