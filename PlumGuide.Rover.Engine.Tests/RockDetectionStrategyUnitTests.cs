using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Strategy;
using System;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class RockDetectionStrategyUnitTests
    {
        [TestMethod]
        public void Algorithm_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var rockDetectionStrategy = new RockDetectionStrategy();

            try
            {
                rockDetectionStrategy.Algorithm(default(Position), default(Position), new bool[1, 1]);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Algorithm_WhenInvokedWithMoveAllowed_ShouldReturnNewPosition()
        {
            var previousPosition = new Position(0, 0, Direction.North);
            var currentPosition = new Position(0, 1, Direction.North);
            var grid = new bool[,]
            {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            };
            var rockDetectionStrategy = new RockDetectionStrategy();

            var postion = rockDetectionStrategy.Algorithm(previousPosition, currentPosition, grid);

            Assert.AreEqual(currentPosition, postion);
        }

        [TestMethod]
        public void Algorithm_WhenInvokedWithNoMoveAllowed_ShouldReturnOldPosition()
        {
            var previousPosition = new Position(0, 0, Direction.North);
            var currentPosition = new Position(1, 0, Direction.North);
            var grid = new bool[,]
            {
                { false, false, false },
                { true, false, false },
                { false, false, false }
            };
            var rockDetectionStrategy = new RockDetectionStrategy();

            Assert.ThrowsException<RockDetectedException>(() => rockDetectionStrategy.Algorithm(previousPosition, currentPosition, grid));
        }
    }
}
