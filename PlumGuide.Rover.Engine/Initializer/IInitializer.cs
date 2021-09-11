namespace PlumGuide.Rover.Engine.Initializer
{
    public interface IInitializer
    {
        (Position, bool[,]) Initialize(Position position, bool[,] grid);
    }
}
