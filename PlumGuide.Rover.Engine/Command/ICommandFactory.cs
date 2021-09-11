namespace PlumGuide.Rover.Engine.Command
{
    public interface ICommandFactory
    {
        ICommand Make(char direction);
    }
}