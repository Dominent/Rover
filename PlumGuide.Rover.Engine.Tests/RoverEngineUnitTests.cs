using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class RoverEngineUnitTests
    {
        [TestMethod]
        public void Start_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var boundary = new Boundary(5, 5);
            var engine = new RoverEngine(boundary);
            var sequence = "FBR";

            try
            {
                engine.Start(sequence);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void RoverEngine_WhenProvidedSequence_ShouldExecuteCorrectly()
        {
            var boundary = new Boundary(100, 100);
            var sequence = "FFRFF";
            var engine = new RoverEngine(boundary);

            var position = engine.Start(sequence);

            Assert.AreEqual(position, new Position(2, 2, Direction.East));
        }

        [TestMethod]
        public void RoverEngine_WhenProvidedSequence_ShouldStopAtRock()
        {
            var boundary = new Boundary(5, 5);
            var grid = new bool[boundary.X, boundary.Y];

            grid[0, 3] = true; // Rock location

            var sequence = "FFF";
            var engine = new RoverEngine(boundary);

            var rockInitializerMock = new Mock<IInitializer>();

            rockInitializerMock
                .Setup(x => x.Initialize(It.IsAny<Position>(), It.IsAny<bool[,]>()))
                .Returns((default(Position), grid));

            RockDetectedException exception = null;

            try
            {
                var postion = engine
                 .AddInitializer(rockInitializerMock.Object)
                 .AddInitializer(new PositionInitializer())
                 .Initialize()
                 .AddStrategy(new RockDetectionStrategy())
                 .Start(sequence);
            }
            catch (RockDetectedException ex)
            {
                exception = ex;
            }

            Assert.AreEqual(exception?.Position, new Position(0, 3, Direction.North));
        }


        [TestMethod]
        public void RoverEngine_WhenProvidedSequence_ShouldWrapAtOtherSide()
        {
            var boundary = new Boundary(100, 100);
            var grid = new bool[boundary.X, boundary.Y];

            var sequence = "B";
            var engine = new RoverEngine(boundary);

            var positon = engine
                .AddInitializer(new PositionInitializer())
                .Start(sequence);

            Assert.AreEqual(positon, new Position(0, boundary.Y - 1, Direction.North));
        }
    }
}
