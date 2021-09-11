using PlumGuide.Rover.Engine;
using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;
using System;
using System.Linq;

namespace PlumGuide.Rover.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            var sequence = Console.ReadLine();

            new RoverEngine(new Boundary(Constants.MAX_X, Constants.MAX_Y))
                .AddStrategy(new RockDetectionStrategy())
                .AddInitializer(new RockInitializer(Constants.ROCKS_ON_PLUTO))
                .AddInitializer(new PositionInitializer())
                .Initialize()
                .Start(sequence);
        }

        private static void PrintGrid(bool[,] grid, Position position)
        {
            for (int y = 0; y < Constants.MAX_Y; y++)
            {
                for (int x = 0; x < Constants.MAX_X; x++)
                {
                    if (grid[x, y])
                    {
                        Console.Write("/\\");
                    }
                    else if (position.X == x && position.Y == y)
                    {
                        Console.Write("**");
                    }
                    else
                    {
                        Console.Write("[]");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine(position);
        }
    }
}
