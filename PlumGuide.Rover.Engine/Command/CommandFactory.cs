using System;
using System.Globalization;

namespace PlumGuide.Rover.Engine.Command
{
    public class CommandFactory : ICommandFactory
    {
        private readonly Boundary _boundary;
        public CommandFactory(Boundary boundary)
        {
            _boundary = boundary;
        }

        public ICommand Make(char direction)
        {
            switch (Char.ToUpper(direction, CultureInfo.InvariantCulture))
            {
                case 'F':
                    return new ForwardMoveCommand(_boundary);
                case 'B':
                    return new BackwardMoveCommand(_boundary);
                case 'L':
                    return new LeftRotationMoveCommand();
                case 'R':
                    return new RightRotationMoveCommand();
                default:
                    throw new NotImplementedException("Command is not implemented");
            }
        }
    }
}
