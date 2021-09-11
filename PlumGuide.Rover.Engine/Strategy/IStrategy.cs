namespace PlumGuide.Rover.Engine.Strategy
{
    public interface IStrategy
    {
        Position Algorithm(Position previous, Position current, bool[,] grid);
    }
}