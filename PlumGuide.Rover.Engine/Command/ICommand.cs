namespace PlumGuide.Rover.Engine.Command
{
    public interface ICommand
    {
        Position Execute(Position position);    
    }
}
