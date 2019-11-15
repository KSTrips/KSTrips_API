using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeajesController : ControllerBase
    {
        private readonly ISimulationService _peajesServices;

        public PeajesController(ISimulationService simulatorServices)
        {
            _peajesServices = simulatorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCategories()
        {
            var result = await _peajesServices.GetCarCategories();
            return Ok(result);
        }

        [HttpGet("expenseCategories")]
        public async Task<IActionResult> GetExpenseCategories()
        {
            var result = await _peajesServices.GetExpenseCategories();
            return Ok(result);
        }


        [HttpGet("{origin}/{destination}")]
        public async Task<IActionResult> GetTollsByRoute(string origin,string destination)
        {
            var result = await _peajesServices.GetTollsByRoute(origin.Trim(),destination.Trim());
            return Ok(result);
        }
    }
}