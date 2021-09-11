namespace PlumGuide.Rover.Engine.Initializer
{
    public class PositionInitializer : IInitializer
    {
        public (Position, bool[,]) Initialize(Position position, bool[,] grid)
        {
            return (new Position(0, 0, Direction.North), grid);
        }
    }
}
