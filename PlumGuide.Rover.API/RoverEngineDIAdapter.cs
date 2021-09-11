using PlumGuide.Rover.Engine;
using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;
using System.Collections.Generic;

namespace PlumGuide.Rover.API
{
    public class RoverEngineDIAdapter
    {
        private readonly IRoverEngine _roverEngine;

        public RoverEngineDIAdapter(
            IRoverEngine roverEngine,
            IEnumerable<IInitializer> initializers,
            IEnumerable<IStrategy> strategies
        )
        {
            foreach (var initializer in initializers)
            {
                roverEngine.AddInitializer(initializer);
            }

            roverEngine.Initialize();

            foreach (var strategy in strategies)
            {
                roverEngine.AddStrategy(strategy);
            }

            _roverEngine = roverEngine;
        }

        public IRoverEngine RoverEngine { get { return _roverEngine; } }
    }
}
