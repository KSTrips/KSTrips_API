using System;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TollsController : ControllerBase
    {
        private readonly ISimulationService _tollsServices;

        public TollsController(ISimulationService simulatorServices)
        {
            _tollsServices = simulatorServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarCategories()
        {
            try
            {
                var result = await _tollsServices.GetCarCategories();
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
                var result = await _tollsServices.GetExpenseCategories();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            
        }


        [HttpGet("{origin}/{destination}")]
        public async Task<IActionResult> GetTollsByRoute(string origin,string destination)
        {
            try
            {
                var result = await _tollsServices.GetTollsByRoute(origin.Trim(),destination.Trim());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
           
        }
    }
}