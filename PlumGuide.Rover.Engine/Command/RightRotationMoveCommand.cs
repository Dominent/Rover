namespace PlumGuide.Rover.Engine.Command
{
    public class RightRotationMoveCommand : MoveCommand
    {
        public override Position Execute(Position position)
        {
            return new Position(
                position.X,
                position.Y, 
                (Direction)Wrap(((int)position.Rotation + Constants.TURN_DEGREES), Constants.MAX_TURN_DEGREES));
        }
    }
}
