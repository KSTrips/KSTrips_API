using System;
using KSTrips.Application.Interfaces;
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

        [HttpGet("expenseReport/{dateFrom}/{dateTo}/{authZeroId}")]
        public IActionResult GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            var result = _reportService.GetReportExpenseByDates(dateFrom, dateTo, authZeroId);
            return Ok(result);
        }
        [HttpGet("detailReport/{dateFrom}/{dateTo}/{authZeroId}")]
        public IActionResult GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            var result = _reportService.GetReportDetailByDates(dateFrom, dateTo, authZeroId);
            return Ok(result);
        }

        [HttpGet("financialReport/{dateFrom}/{dateTo}/{authZeroId}")]
        public IActionResult GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            var result = _reportService.GetReportFinancialByDates(dateFrom, dateTo, authZeroId);
            return Ok(result);
        }
    }
}