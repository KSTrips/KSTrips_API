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
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{dateFrom}/{dateTo}/{authZeroId}")]
        public IActionResult GetReportByDates(DateTime dateFrom, DateTime dateTo,string authZeroId)
        {
            var result =  _reportService.GetReportQtyByDates(dateFrom,dateTo,authZeroId);
            return Ok(result);
        }

    }
}