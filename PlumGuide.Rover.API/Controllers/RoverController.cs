using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlumGuide.Rover.API.Models.Input;
using PlumGuide.Rover.API.Models.Output;
using PlumGuide.Rover.Engine.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlumGuide.Rover.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoverController : ControllerBase
    {
        private readonly ILogger<RoverController> _logger;
        private readonly RoverEngineDIAdapter _roverEngineDIAdapter;

        public RoverController(RoverEngineDIAdapter roverEngineDIAdapter, ILogger<RoverController> logger)
        {
            _logger = logger;
            _roverEngineDIAdapter = roverEngineDIAdapter;
        }

        [HttpPost(nameof(SendCommand))]
        public ActionResult<SendCommandOutputModel> SendCommand([FromBody] SendCommandInputModel sendCommandInputModel)
        {
            var roverEngine = _roverEngineDIAdapter.RoverEngine;

            try
            {
                var position = roverEngine.Start(sendCommandInputModel.Sequence);

                return this.Ok(new SendCommandOutputModel()
                {
                    Position = position
                });
            }
            catch (RockDetectedException ex)
            {
                _logger.LogError(ex.Message);

                return this.BadRequest(new SendCommandOutputModel()
                {
                    Position = ex.Position,
                    Errors = new[] { ex.Message }
                });
            }
        }
    }
}
