using System;

namespace PlumGuide.Rover.Engine.Command
{
    public class BackwardMoveCommand : MoveCommand
    {
        private readonly Boundary _boundary;

        public BackwardMoveCommand(Boundary boundary)
        {
            _boundary = boundary;
        }

        public override Position Execute(Position position)
        {
            switch (position.Rotation)
            {
                case Direction.North:
                    return new Position(position.X, Wrap(position.Y - 1, _boundary.Y), position.Rotation);
                case Direction.South:
                    return new Position(position.X, Wrap(position.Y + 1, _boundary.Y), position.Rotation);
                case Direction.East:
                    return new Position(Wrap(position.X + 1, _boundary.X), position.Y, position.Rotation);
                case Direction.West:
                    return new Position(Wrap(position.X - 1, _boundary.X), position.Y, position.Rotation);
                default:
                    throw new NotImplementedException("Direction is not implemented!");
            }
        }
    }
}
