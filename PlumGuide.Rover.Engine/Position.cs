using System;

namespace PlumGuide.Rover.Engine
{
    public struct Position
    {
        public Position(int x, int y, Direction rotation)
        {
            X = x;
            Y = y;
            Rotation = rotation;
        }

        public int X { get; set; }

        public int Y { get; set; }

        public Direction Rotation { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   X == position.X &&
                   Y == position.Y &&
                   Rotation == position.Rotation;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Rotation);
        }

        public override string ToString()
        {
            return $"X: {X}, Y: {Y}, Dir: {Rotation}";
        }
    }
}
