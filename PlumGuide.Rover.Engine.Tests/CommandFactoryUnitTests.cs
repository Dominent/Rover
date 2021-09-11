using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Command;
using System;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class CommandFactoryUnitTests
    {
        [TestMethod]
        public void Make_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var boundary = new Boundary(5, 5);
            var direction = 'F';

            var commandFactory = new CommandFactory(boundary);

            try
            {
                commandFactory.Make(direction);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void Make_WhenInvokedWithMissingDirection_ShouldThrowNotImplementedError()
        {
            var boundary = new Boundary(5, 5);
            var direction = 'X';

            var commandFactory = new CommandFactory(boundary);

            Assert.ThrowsException<NotImplementedException>(() => commandFactory.Make(direction));
        }

        [TestMethod]
        public void Make_WhenInvokedWithForward_ShouldReturnForwardCommand()
        {
            var boundary = new Boundary(5, 5);

            var commandFactory = new CommandFactory(boundary);

            var command = commandFactory.Make('F');

            Assert.IsInstanceOfType(command, typeof(ForwardMoveCommand));
        }

        [TestMethod]
        public void Make_WhenInvokedWithBackward_ShouldReturnBackwardCommand()
        {
            var boundary = new Boundary(5, 5);

            var commandFactory = new CommandFactory(boundary);

            var command = commandFactory.Make('B');

            Assert.IsInstanceOfType(command, typeof(BackwardMoveCommand));
        }

        [TestMethod]
        public void Make_WhenInvokedWithLeft_ShouldReturnLeftRotationCommand()
        {
            var boundary = new Boundary(5, 5);

            var commandFactory = new CommandFactory(boundary);

            var command = commandFactory.Make('L');

            Assert.IsInstanceOfType(command, typeof(LeftRotationMoveCommand));
        }

        [TestMethod]
        public void Make_WhenInvokedWithRight_ShouldReturnRightRotationCommand()
        {
            var boundary = new Boundary(5, 5);

            var commandFactory = new CommandFactory(boundary);

            var command = commandFactory.Make('R');

            Assert.IsInstanceOfType(command, typeof(RightRotationMoveCommand));
        }
    }
}
