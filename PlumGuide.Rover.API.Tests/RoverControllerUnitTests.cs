using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlumGuide.Rover.API.Controllers;
using PlumGuide.Rover.API.Models.Input;
using PlumGuide.Rover.API.Models.Output;
using PlumGuide.Rover.Engine;
using PlumGuide.Rover.Engine.Initializer;
using PlumGuide.Rover.Engine.Strategy;
using System.Net;

namespace PlumGuide.Rover.API.Tests
{
    [TestClass]
    public class RoverControllerUnitTests
    {
        [TestMethod]
        public void SendCommand_WhenInvoked_ShouldReturnCorrectPosition()
        {
            var sendCommandInputModel = new SendCommandInputModel() { Sequence = "FRLFBRFF" };

            var sendCommandOutputModel = new SendCommandOutputModel()
            {
                Position = new Position(2, 1, Direction.East),
                Errors = null
            };

            var roverEngineDIAdapter = new RoverEngineDIAdapter(
                new RoverEngine(new Boundary(100, 100)),
                new IInitializer[] { new PositionInitializer(), new RockInitializer(Constants.ROCKS_ON_PLUTO) },
                new IStrategy[] { new RockDetectionStrategy() }
            );

            var loggerStub = new Mock<ILogger<RoverController>>();

            var controller = new RoverController(roverEngineDIAdapter, loggerStub.Object);

            var actual = controller.SendCommand(sendCommandInputModel);

            Assert.AreEqual(sendCommandOutputModel, (actual.Result as ObjectResult).Value);
            Assert.AreEqual(200, (actual.Result as ObjectResult).StatusCode);
        }
    }
}
