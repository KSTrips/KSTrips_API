using System;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KSTrips_API.Controllers
{
    [Route("v1/Trips")]
    [ApiController]
    [Authorize]
    public class TripController: ControllerBase
    {

        private readonly ISimulationService _simulatorServices;
        private readonly ITripService _tripServices;

        public TripController(ISimulationService simulatorServices, ITripService tripServices)
        {
            _simulatorServices = simulatorServices;
            _tripServices = tripServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarTypes()
        {
            try
            {
                var result = await _simulatorServices.GetCarTypes();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("expenseCategories")]
        public async Task<IActionResult> GetExpenseCategories()
        {
            try
            {
                var result = await _simulatorServices.GetExpenseCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetTripByUserId(string userId)
        {
            try
            {
                var result = await _tripServices.GetTripsByUserId(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            
        }

        [HttpGet("getTripById/{tripId}")]
        public async Task<IActionResult> GetTripById(int tripId)
        {
            try
            {
                var result = await _tripServices.GetTripById(tripId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }



        // POST api/values
        [HttpPost("SaveTrip")]
        public async Task<IActionResult> SaveTrip([FromBody] SimulatorEntity dataTrip)
        {
            try
            {

                var result = await _tripServices.SaveTrip(dataTrip);

                if (result != null)
                {
                    return Ok(JsonConvert.SerializeObject(result, Formatting.Indented,
                        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                }
                else
                {
                    return BadRequest("Error guardando el viaje, por favor intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPut("UpdateTrip")]
        public async Task<IActionResult> UpdateTrip([FromBody] SimulatorEntity dataTrip)
        {
            try
            {
                var result = await _tripServices.UpdateTrip(dataTrip);

                if (result != null)
                {
                    return Ok(JsonConvert.SerializeObject(result, Formatting.Indented,
                        new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
                }
                else
                {
                    return BadRequest("Error actualizando el viaje, por favor intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPut("UpdateCloseTrip")]
        public async Task<IActionResult> UpdateCloseTrip([FromBody] int tripId)
        {
            try
            {
                var result = await _tripServices.UpdateCloseTrip(tripId);

                if (result != null)
                {
                    return Ok(JsonConvert.SerializeObject(result, Formatting.Indented,
                        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
                }
                else
                {
                    return BadRequest("Error actualizando el viaje, por favor intente de nuevo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}
