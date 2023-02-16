using ToyRobotTest.Robot.Enum;
using ToyRobotTest.Checker.Interface;

namespace ToyRobotTest.Checker
{
    public class InputParser : IInputParser
    {
        public Command ParseCommand(string[] rawInput)
        {
            Command command;
            if (!Enum.TryParse(rawInput[0], true, out command))
                throw new ArgumentException("\nSorry, your command was not recognised. Please try again using the following format: PLACE X,Y,F|MOVE|LEFT|RIGHT|REPORT");
            return command;
        }
        public PlaceCommandParameter ParseCommandParameter(string[] input)
        {
            var thisPlaceCommandParameter = new PlaceCommandParameterParser();
            return thisPlaceCommandParameter.ParseParameters(input);
        }
    }
}
