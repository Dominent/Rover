namespace PlumGuide.Rover.Engine
{
    public struct Boundary
    {
        public Boundary(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
