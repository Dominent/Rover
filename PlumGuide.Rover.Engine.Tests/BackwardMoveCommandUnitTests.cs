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
    public class BackwardMoveCommandUnitTests
    {
        [TestMethod]
        public void Execute_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var backwardMoveCommand = new BackwardMoveCommand(new Boundary(5, 5));

            var position = new Position(0, 0, Direction.North);

            try
            {
                backwardMoveCommand.Execute(position);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Execute_WhenInvokedWithNorthDirection_ShouldWrapToBottom()
        {
            var boundary = new Boundary(5, 5);
            var backwardMoveCommand = new BackwardMoveCommand(boundary);

            var position = new Position(0, 0, Direction.North);


            var actual = backwardMoveCommand.Execute(position);

            var expected = new Position(position.X, boundary.Y - 1, position.Rotation);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithSouthDirection_ShouldMoveCorrectly()
        {
            var boundary = new Boundary(5, 5);
            var backwardMoveCommand = new BackwardMoveCommand(boundary);

            var position = new Position(0, 0, Direction.South);


            var actual = backwardMoveCommand.Execute(position);

            var expected = new Position(position.X, position.Y + 1, position.Rotation);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithEastDirection_ShouldMoveCorrectly()
        {
            var boundary = new Boundary(5, 5);
            var backwardMoveCommand = new BackwardMoveCommand(boundary);

            var position = new Position(0, 0, Direction.East);

            var actual = backwardMoveCommand.Execute(position);

            var expected = new Position(position.X + 1, position.Y, position.Rotation);

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Execute_WhenInvokedWithWestDirection_ShouldMoveCorrectly()
        {
            var boundary = new Boundary(5, 5);
            var backwardMoveCommand = new BackwardMoveCommand(boundary);

            var position = new Position(0, 0, Direction.West);

            var actual = backwardMoveCommand.Execute(position);

            var expected = new Position(boundary.X - 1, position.Y, position.Rotation);

            Assert.AreEqual(actual, expected);
        }
    }
}
