using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Command;
using System;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class LeftRotationMoveCommandUnitTests
    {
        [TestMethod]
        public void Execute_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var leftRotationMoveCommand = new LeftRotationMoveCommand();

            var position = new Position(0, 0, Direction.North);

            try
            {
                leftRotationMoveCommand.Execute(position);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Execute_WhenInvokedWithNorthDirection_ShouldRotateDirectionToWest()
        {
            var leftRotationMoveCommand = new LeftRotationMoveCommand();

            var position = new Position(0, 0, Direction.North);

            var actual = leftRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.West);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithEastDirection_ShouldRotateDirectionToNorth()
        {
            var leftRotationMoveCommand = new LeftRotationMoveCommand();

            var position = new Position(0, 0, Direction.East);

            var actual = leftRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.North);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithSouthDirection_ShouldRotateDirectionToEast()
        {
            var leftRotationMoveCommand = new LeftRotationMoveCommand();

            var position = new Position(0, 0, Direction.South);

            var actual = leftRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.East);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithWestDirection_ShouldRotateDirectionToSouth()
        {
            var leftRotationMoveCommand = new LeftRotationMoveCommand();

            var position = new Position(0, 0, Direction.West);

            var actual = leftRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.South);

            Assert.AreEqual(actual, expected);
        }
    }
}
