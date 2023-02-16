using ToyRobotTest.Robot;
using ToyRobotTest.Board.Interface;

namespace ToyRobotTest.Board
{
    public class Board : IBoard
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Board(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;
        }

        public bool IsValidPosition(Position position)
        {
            return position.X < (Columns + 1) && position.X >= 1 &&
                   position.Y < (Rows + 1) && position.Y >= 1;
        }
    }
}
