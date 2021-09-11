using PlumGuide.Rover.Engine.Command;
using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlumGuide.Rover.Engine
{
    public class RoverEngine : IRoverEngine
    {
        private readonly Boundary _boundary;
        private readonly ICommandFactory _commandFactory;
        private readonly IList<IStrategy> _strategies;
        private readonly IList<IInitializer> _initializers;

        private Position _position;
        private bool[,] _grid;

        public RoverEngine(Boundary boundary)
        {
            _boundary = boundary;
            
            _strategies = new List<IStrategy>();
            _initializers = new List<IInitializer>();
            _grid = new bool[_boundary.X, _boundary.Y];
            _position = default(Position);

            //INFO(PPavlov): Poor man's DI
            //TODO(PPavlov): New is glue, remove from here
            _commandFactory = new CommandFactory(boundary);
        }

        public RoverEngine AddStrategy(IStrategy strategy)
        {
            _strategies.Add(strategy);

            return this;
        }

        public RoverEngine AddInitializer(IInitializer initializer)
        {
            _initializers.Add(initializer);

            return this;
        }

        public virtual Position Start(string sequence)
        {
            foreach (var direction in sequence)
            {
                var command = _commandFactory.Make(direction);

                var newPosition = command.Execute(_position);

                if (_strategies.Any())
                {
                    foreach (var strategy in _strategies)
                    {
                        _position = strategy.Algorithm(_position, newPosition, _grid);
                    }
                }
                else
                {
                    _position = newPosition;
                }
            }

            return _position;
        }

        public virtual RoverEngine Initialize()
        {
            foreach (var initializer in _initializers)
            {
                (_position, _grid) = initializer.Initialize(_position, _grid);
            }

            return this;
        }
    }
}
