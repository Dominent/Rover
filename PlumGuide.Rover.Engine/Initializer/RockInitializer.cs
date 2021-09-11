using System;

namespace PlumGuide.Rover.Engine.Initializer
{
    public interface IRandomGenerator
    {
        int Next(int min, int max);
    }

    public class RandomGenerator : IRandomGenerator
    {
        private readonly Random _random;

        public RandomGenerator(Random random)
        {
            _random = random;
        }

        public int Next(int min, int max)
        {
            return _random.Next(min, max);
        }
    }

    public class RockInitializer : IInitializer
    {
        private readonly int _rocksOnPluto;

        public RockInitializer(int rocksOnPluto)
        {
            _rocksOnPluto = rocksOnPluto;
        }

        protected virtual IRandomGenerator MakeRandomGenerator()
        {
            return new RandomGenerator(new Random());
        }

        public (Position, bool[,]) Initialize(Position position, bool[,] grid)
        {
            var populatedGrid = grid.Clone() as bool[,];

            var random = this.MakeRandomGenerator();
            for (int i = 0; i < _rocksOnPluto; i++)
            {
                var rockPositionXIndex = random.Next(0, grid.GetLength(0) - 1);
                var rockPositionYIndex = random.Next(0, grid.GetLength(1) - 1);

                populatedGrid[rockPositionXIndex, rockPositionYIndex] = true;
            }

            return (position, grid);
        }
    }
}
