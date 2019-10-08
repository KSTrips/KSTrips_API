using System.Net;
using System.Threading.Tasks;
using KSTrips_API.Core.Interfaces;
using KSTrips_API.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SimulatorController : ControllerBase
    {
        private readonly ISimulatorService _simulatorServices;

        public SimulatorController(ISimulatorService simulatorServices)
        {
            _simulatorServices = simulatorServices;
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


        // POST api/values
        [HttpPost("SimulateTrip")]
        public async Task<IActionResult> Post([FromBody] SimulatorEntity dataSimulator)
        {
            var result = (await _simulatorServices.SimulateTripAsync(dataSimulator));

            return Ok(JsonConvert.SerializeObject(result,Formatting.Indented,new JsonSerializerSettings{ReferenceLoopHandling = ReferenceLoopHandling.Ignore}));

        }

    }
}