using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetCarCategories()
        {
            var result = await _simulatorServices.GetCarCategories();
            return Ok(result);
        }

        [HttpGet("expenseCategories")]
        public async Task<IActionResult> GetExpenseCategories()
        {
            var result = await _simulatorServices.GetExpenseCategories();
            return Ok(result);
        }

        [HttpGet("{authZeroId}")]
        public async Task<IActionResult> GetTripByUserId(string authZeroId)
        {
            var result = await _tripServices.GetTripsByUserId(authZeroId);
            return Ok(result);
        }

        // POST api/values
        [HttpPost("SaveTrip")]
        public async Task<IActionResult> SaveTrip([FromBody] SimulatorEntity dataTrip)
        {
            var result = await _tripServices.SaveTrip(dataTrip);

            if (result != null)
            {
                return Ok(JsonConvert.SerializeObject(result, Formatting.Indented,
                    new JsonSerializerSettings {ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));
            }
            else
            {
                return BadRequest("Error guardando el viaje, por favor intente de nuevo");
            }
        }

        // POST api/values
        [HttpPost("UpdateTrip")]
        public async Task<IActionResult> UpdateTrip([FromBody] SimulatorEntity dataTrip)
        {
            var result = await _tripServices.UpdateTrip(dataTrip);

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

    }
}
