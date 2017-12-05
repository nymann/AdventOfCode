using System.Drawing;

namespace AdventOfCode._2016.Day1
{
    /// <summary>
    /// contains Direction and current position
    /// </summary>
    public class PositionDirection
    {
        public Direction Direction;
        public Point Position;

        public PositionDirection()
        {
            Direction = Direction.N;
            Position = new Point(0, 0);
        }
    }
}