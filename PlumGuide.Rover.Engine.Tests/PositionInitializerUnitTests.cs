using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Initializer;
using System;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class PositionInitializerUnitTests
    {
        [TestMethod]
        public void Initialize_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var position = new Position(0, 0, Direction.North);
            var grid = new bool[5, 5];

            var positionInitializer = new PositionInitializer();

            try
            {
                positionInitializer.Initialize(position, grid);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Initialize_WhenInvoked_ShouldReturnCorrectPosition()
        {
            var grid = new bool[5, 5];

            var positionInitializer = new PositionInitializer();

            var (position, _) = positionInitializer.Initialize(default(Position), grid);

            Assert.AreEqual(position, new Position(0, 0, Direction.North));
        }

        [TestMethod]
        public void Initialize_WhenInvoked_ShouldNotChangeGrid()
        {
            var grid = new bool[5, 5];

            var positionInitializer = new PositionInitializer();

            var (_, newGrid) = positionInitializer.Initialize(default(Position), grid);

            CollectionAssert.AreEqual(grid, newGrid);
        }
    }
}
