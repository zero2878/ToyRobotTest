using ToyRobotTest.Robot;
using ToyRobotTest.Robot.Enum;

namespace ToyRobotTest.Checker
{
    public class PlaceCommandParameter
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }

        public PlaceCommandParameter(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
