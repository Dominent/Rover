namespace PlumGuide.Rover.Engine.Command
{
    public abstract class MoveCommand : ICommand
    {
        public abstract Position Execute(Position position);

        protected virtual int Wrap(int value, int boundary)
        {
            if (value < 0)
            {
                return value + boundary;
            }
            else if (value >= boundary)
            {
                return value % boundary;
            }

            return value;
        }
    }
}
