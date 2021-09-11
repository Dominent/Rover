using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlumGuide.Rover.Engine.Initializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumGuide.Rover.Engine.Tests
{
    public class RockInitializerStub : RockInitializer
    {
        private readonly IRandomGenerator _randomGenerator;

        public RockInitializerStub(IRandomGenerator randomGenerator, int rocksOnPluto)
            :base(rocksOnPluto)
        {
            _randomGenerator = randomGenerator;
        }

        protected override IRandomGenerator MakeRandomGenerator()
        {
            return _randomGenerator;
        }
    }

    [TestClass]
    public class RockInitializerUnitTests
    {
        [TestMethod]
        public void Initialize_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var rocksOnPluto = 5;
            var position = new Position(0, 0, Direction.North);
            var grid = new bool[5, 5];

            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock
                .Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0);

            var rockInitializer = new RockInitializerStub(
                randomGeneratorMock.Object,
                rocksOnPluto
            );

            try
            {
                rockInitializer.Initialize(position, grid);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }

        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        [DataRow(42)]
        public void Initialize_WhenInvokedNTimes_ShouldInvokeNRandomNumbers(int rocksOnPluto)
        {
            var gridLength = rocksOnPluto;
            var position = new Position(0, 0, Direction.North);
            var grid = new bool[gridLength, gridLength];

            var randomGeneratorMock = new Mock<IRandomGenerator>();
            randomGeneratorMock
                .Setup(x => x.Next(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(0);

            var rockInitializer = new RockInitializerStub(
              randomGeneratorMock.Object,
              rocksOnPluto
            );

            rockInitializer.Initialize(position, grid);

            //INFO(PPavlov): We multiply by two because next is called to generate a number once for x and once for y
            randomGeneratorMock
                .Verify(
                    r => r.Next(0, gridLength - 1),
                    Times.Exactly(gridLength * 2)
                );
        }
    }
}
