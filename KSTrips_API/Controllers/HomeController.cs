using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHomeService _ihomeservices;

        public HomeController(IHomeService ihomeservices)
        {
            _ihomeservices = ihomeservices;
        }

        [HttpGet]
        public async Task<IActionResult> GetHome()
        {
            return Ok();
        }

        [HttpGet("GetPromotionalVideo")]
        public async Task<IActionResult> GetPromotionalVideo()
        {
            var result = _ihomeservices.GetPromotionalVideo();
            return Ok(result);
        }

        [HttpGet("GetHowUseAppVideo")]
        public async Task<IActionResult> GetHowUseAppVideo()
        {
            var result = _ihomeservices.GetHowUseAppVideo();
            return Ok(result);
        }
    }
}