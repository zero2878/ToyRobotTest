using NUnit.Framework;
using ToyRobotTest.Checker;
using ToyRobotTest.Behavior;
using ToyRobotTest.Robot.Interface;
using ToyRobotTest.Board.Interface;
using ToyRobotTest.Checker.Interface;
using ToyRobotTest.Robot.Enum;

namespace ToyRobotTest.Test
{
    [TestFixture]
    public class TestBehaviour
    {
        /// <summary>
        /// Test a valid place command
        /// </summary>
        [Test]
        public void TestValidBehaviourPlace()
        {
            // arrange
            IBoard squareBoard = new Board.Board(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot.Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 1,4,EAST".Split(' '));

            // assert
            Assert.AreEqual(1, robot.Position.X);
            Assert.AreEqual(4, robot.Position.Y);
            Assert.AreEqual(Direction.East, robot.Direction);
        }

        /// <summary>
        /// Test an invalid place command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourPlace()
        {
            // arrange
            IBoard squareBoard = new Board.Board(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot.Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 9,7,EAST".Split(' '));

            // assert
            Assert.IsNull(robot.Position);
        }

        /// <summary>
        /// Test a valid move command
        /// </summary>
        [Test]
        public void TestValidBehaviourMove()
        {
            // arrange
            IBoard squareBoard = new Board.Board(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot.Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,2,SOUTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("\nRobot Location: 3,3,SOUTH", simulator.GetReport());
        }

        /// <summary>
        /// Test and invalid move command
        /// </summary>
        [Test]
        public void TestInvalidBehaviourMove()
        {
            // arrange
            IBoard squareBoard = new Board.Board(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot.Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 2,2,NORTH".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            // if the robot goes out of the board it ignores the command
            simulator.ProcessCommand("MOVE".Split(' '));

            // assert
            Assert.AreEqual("\nRobot Location: 2,1,NORTH", simulator.GetReport());
        }

        /// <summary>
        /// Test valid movement in the board and test report
        /// </summary>
        [Test]
        public void TestValidBehaviourReport()
        {
            // arrange
            IBoard squareBoard = new Board.Board(5, 5);
            IInputParser inputParser = new InputParser();
            IRobot robot = new Robot.Robot();
            var simulator = new Behaviour(robot, squareBoard, inputParser);

            // act
            simulator.ProcessCommand("PLACE 3,3,WEST".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            simulator.ProcessCommand("LEFT".Split(' '));
            simulator.ProcessCommand("MOVE".Split(' '));
            var output = simulator.ProcessCommand("REPORT".Split(' '));

            // assert
            Assert.AreEqual("\nRobot Location: 1,4,SOUTH", output);
        }
    }
}
