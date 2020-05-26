using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SimulatorController : ControllerBase
    {
        private readonly ISimulationService _simulatorServices;

        public SimulatorController(ISimulationService simulatorServices)
        {
            _simulatorServices = simulatorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarTypes()
        {
            var result = await _simulatorServices.GetCarTypes();
            return Ok(result);
        }

        [HttpGet("expenseCategories")]
        public async Task<IActionResult> GetExpenseCategories()
        {
            var result = await _simulatorServices.GetExpenseCategories();
            return Ok(result);
        }


        // POST api/values
        [HttpPost("SimulateTrip")]
        public async Task<IActionResult> SimulateTrip([FromBody] SimulatorEntity dataSimulator)
        {
            var result = (await _simulatorServices.SimulateTripAsync(dataSimulator));

            return Ok(JsonConvert.SerializeObject(result,Formatting.Indented,new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));

        }

    }
}