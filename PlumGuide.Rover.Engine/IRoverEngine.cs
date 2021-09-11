using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;

namespace PlumGuide.Rover.Engine
{
    public interface IRoverEngine
    {
        RoverEngine AddInitializer(IInitializer initializer);
        RoverEngine AddStrategy(IStrategy strategy);
        RoverEngine Initialize();
        Position Start(string sequence);
    }
}