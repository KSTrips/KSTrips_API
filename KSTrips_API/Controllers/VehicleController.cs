using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ISimulationService _simulatorServices;
        private readonly IVehicleService _vehicleServices;

        public VehicleController(IVehicleService vehicleServices, ISimulationService simulatorServices)
        {
            _vehicleServices = vehicleServices;
            _simulatorServices = simulatorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCategories()
        {
            var result = await _simulatorServices.GetCarCategories();
            return Ok(result);
        }


        [HttpGet("{authZeroId}")]
        public async Task<IActionResult> GetUserByAuthZeroId(string authZeroId)
        {

            List<Vehicle> result = await _vehicleServices.GetVehiclesByUser(authZeroId);
            return Ok(result);
        }

        // POST api/saveUsers
        [HttpPost("SaveVehicles")]
        public IActionResult SaveVehicles([FromBody] List<InComingVehicles> dataVehicle)
        {
            var result = _vehicleServices.SaveVehicles(dataVehicle);

            if (result)
                return Ok();

            return BadRequest("Error: al guardar los vehiculos");

        }

        // POST api/updateUsers
        [HttpPost("UpdateVehicles")]
        public IActionResult UpdateVehicles([FromBody] List<InComingVehicles> dataVehicle)
        {
            var result = _vehicleServices.UpdateVehicles(dataVehicle);

            if (result)
                return Ok();

            return BadRequest("Error: al actualizar los vehiculos");

        }
    }
}