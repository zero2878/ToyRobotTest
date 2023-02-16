using ToyRobotTest.Robot.Enum;

namespace ToyRobotTest.Checker.Interface
{
    public interface IInputParser
    {
        Command ParseCommand(string[] rawInput);
        PlaceCommandParameter ParseCommandParameter(string[] input);
    }
}
