using System;
using System.Text;
using Demo_API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Demo_API.Controllers
{
    [ApiController]
    [Route("/Ship/")]
    public class ShipController : ControllerBase
    {
        private readonly IShipStorage _shipStorage;

        public ShipController(IShipStorage shipStorage)
        {
            _shipStorage = shipStorage;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateShip()
        {
            string json;
            using (StreamReader reader = new StreamReader(this.Request.Body, Encoding.UTF8))
            {
                json = await reader.ReadToEndAsync();

            }

            return _shipStorage.CreateShip(json) ? Ok() : BadRequest();
        }

        [HttpGet("Read/{ShipID}")]
        public IActionResult ReadShip(string shipID)
        {
            return Ok(_shipStorage.ReadShip(shipID));
        }

        [HttpGet("ReadAll")]
        public IActionResult ReadAllShip()
        {
            return Ok(_shipStorage.GetAllShips());
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateShip()
        {
            string json;
            using (StreamReader reader = new StreamReader(this.Request.Body, Encoding.UTF8))
            {
                json = await reader.ReadToEndAsync();

            }

            return _shipStorage.UpdateShip(json) ? Ok() : BadRequest();
        }

        [HttpDelete("Delete/{ShipID}")]
        public async Task<IActionResult> DeleteShip(string shipID)
        {
            return _shipStorage.DeleteShip(shipID) ? Ok() : BadRequest();
        }

    }
}

