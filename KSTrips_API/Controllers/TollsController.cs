using System;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("v1/Tolls")]
    [ApiController]
    [Authorize]

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

    }
}