using NUnit.Framework;
using ToyRobotTest.Robot;

namespace ToyRobotTest.Test
{
    [TestFixture]
    public class TestBoard
    {

        /// <summary>
        /// Try to put the toy outside of the board
        /// </summary>
        [Test]
        public void TestInvalidBoardPosition()
        {
            // arrange
            Board.Board squareBoard = new Board.Board(5, 5);
            Position position = new Position(6, 6);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test valid positon 
        /// </summary>
        [Test]
        public void TestValidBoardPosition()
        {
            // arrange
            Board.Board squareBoard = new Board.Board(5, 5);
            Position position = new Position(1, 4);

            // act
            var result = squareBoard.IsValidPosition(position);

            // assert
            Assert.IsTrue(result);
        }

    }
}
