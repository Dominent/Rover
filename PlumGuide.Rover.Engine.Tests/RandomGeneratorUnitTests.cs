using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.Rover.Engine.Initializer;
using System;

namespace PlumGuide.Rover.Engine.Tests
{
    [TestClass]
    public class RandomGeneratorUnitTests
    {
        [TestMethod]
        public void Next_WhenInvoked_ShouldNotThrowNotImplementedError()
        {
            var randomGenerator = new RandomGenerator(new Random());

            try
            {
                randomGenerator.Next(0, 1);
            }
            catch (NotImplementedException)
            {
                Assert.Fail();
            }
        }
    }
}
