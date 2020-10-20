using System;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("v1/Reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{dateFrom}/{dateTo}/{authZeroId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportByDates(DateTime dateFrom, DateTime dateTo,string authZeroId, int vehicleId)
        {
            try
            {
                var result =  _reportService.GetReportQtyByDates(dateFrom,dateTo,authZeroId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("expenseReport/{dateFrom}/{dateTo}/{authZeroId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportExpenseByDates(dateFrom, dateTo, authZeroId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("detailReport/{dateFrom}/{dateTo}/{authZeroId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportDetailByDates(dateFrom, dateTo, authZeroId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("financialReport/{dateFrom}/{dateTo}/{authZeroId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportFinancialByDates(dateFrom, dateTo, authZeroId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("dashboardReport/{dateFrom}/{dateTo}/{authZeroId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetDashboardReport(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            try
            {
                var result = _reportService.GetDashboardReport(dateFrom, dateTo, authZeroId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("getMaintenanceVehicles/{dateFrom}/{dateTo}/{authZeroId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetMaintenanceVehicles(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            try
            {
                var result = _reportService.GetMaintenanceVehicles(dateFrom, dateTo, authZeroId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}