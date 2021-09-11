using System;

namespace PlumGuide.Rover.Engine.Strategy
{
    public class RockDetectedException : Exception
    {
        public Position Position { get; set; }

        public RockDetectedException(Position position)
            : base($"Rock Detected at position: {position}")
        {
            this.Position = position;
        }
    }

    public class RockDetectionStrategy : IStrategy
    {
        public Position Algorithm(Position previous, Position current, bool[,] grid)
        {
            if (grid[current.X, current.Y])
            {
                throw new RockDetectedException(current);
            }

            return current;
        }
    }
}
