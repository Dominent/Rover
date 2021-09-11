using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Command;

namespace PlumGuide.Rover.Engine.Tests
{
    public class MoveCommandMock : MoveCommand
    {
        public int WrapExposed(int value, int boundary)
        {
            return this.Wrap(value, boundary);
        }

        public override Position Execute(Position position)
        {
            throw new System.NotImplementedException();
        }
    }

    [TestClass]
    public class MoveCommandUnitTests
    {
        [TestMethod]
        public void Wrap_WhenInvokedWithNegativeIndex_ShouldWrapToMaxIndexValue()
        {
            var mock = new MoveCommandMock();

            var index = -1;
            var boundary = Constants.MAX_X;

            var expectedIndex = Constants.MAX_X - 1;

            Assert.AreEqual(mock.WrapExposed(index, boundary), expectedIndex);
        }

        [TestMethod]
        public void Wrap_WhenInvokedWithPositiveIndexBiggerThanBoundary_ShouldWrapZeroIndex()
        {
            var mock = new MoveCommandMock();

            var index = Constants.MAX_X;
            var boundary = Constants.MAX_X;

            var expectedIndex = 0;

            Assert.AreEqual(mock.WrapExposed(index, boundary), expectedIndex);
        }

        [TestMethod]
        public void Wrap_WhenInvokedWithValidIndex_ShouldReturnSameIndex()
        {
            var mock = new MoveCommandMock();

            var index = Constants.MAX_X / 2;
            var boundary = Constants.MAX_X;

            var expectedIndex = Constants.MAX_X / 2;

            Assert.AreEqual(mock.WrapExposed(index, boundary), expectedIndex);
        }

        [TestMethod]
        public void Wrap_WhenInvokedWithNegativeDirection_ShouldWrapCorrectDirection()
        {
            var mock = new MoveCommandMock();

            var direction = Direction.North - Constants.TURN_DEGREES;
            var boundary = Constants.MAX_TURN_DEGREES;

            var expectedDirection = Direction.West;

            Assert.AreEqual(mock.WrapExposed((int)direction, boundary), (int)expectedDirection);
        }
    }
}
