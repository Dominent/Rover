using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class RightRotationMoveCommandUnitTests
    {
        [TestMethod]
        public void Execute_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var rightRotationMoveCommand = new RightRotationMoveCommand();

            var position = new Position(0, 0, Direction.North);

            try
            {
                rightRotationMoveCommand.Execute(position);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Execute_WhenInvokedWithNorthDirection_ShouldRotateDirectionToEast()
        {
            var rightRotationMoveCommand = new RightRotationMoveCommand();

            var position = new Position(0, 0, Direction.North);

            var actual = rightRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.East);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithWestDirection_ShouldRotateDirectionToNorth()
        {
            var rightRotationMoveCommand = new RightRotationMoveCommand();

            var position = new Position(0, 0, Direction.West);

            var actual = rightRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.North);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithSouthDirection_ShouldRotateDirectionToWest()
        {
            var leftRotationMoveCommand = new RightRotationMoveCommand();

            var position = new Position(0, 0, Direction.South);

            var actual = leftRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.West);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithEastDirection_ShouldRotateDirectionToSouth()
        {
            var rightRotationMoveCommand = new RightRotationMoveCommand();

            var position = new Position(0, 0, Direction.East);

            var actual = rightRotationMoveCommand.Execute(position);

            var expected = new Position(0, 0, Direction.South);

            Assert.AreEqual(actual, expected);
        }
    }
}
