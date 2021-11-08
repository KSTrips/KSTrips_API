using System;
using KSTrips.Application.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KSTrips_API.Controllers
{
    [Route("v1/Reports")]
    [ApiController]
    //[Authorize]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{dateFrom}/{dateTo}/{userId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportByDates(DateTime dateFrom, DateTime dateTo,string userId, int vehicleId)
        {
            try
            {
                var result =  _reportService.GetReportQtyByDates(dateFrom,dateTo,userId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("expenseReport/{dateFrom}/{dateTo}/{userId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportExpenseByDates(dateFrom, dateTo, userId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpGet("detailReport/{dateFrom}/{dateTo}/{userId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportDetailByDates(dateFrom, dateTo, userId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("financialReport/{dateFrom}/{dateTo}/{userId}/{vehicleId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId)
        {
            try
            {
                var result = _reportService.GetReportFinancialByDates(dateFrom, dateTo, userId,vehicleId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("dashboardReport/{dateFrom}/{dateTo}/{userId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetDashboardReport(DateTime dateFrom, DateTime dateTo, string userId)
        {
            try
            {
                var result = _reportService.GetDashboardReport(dateFrom, dateTo, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("getMaintenanceVehicles/{dateFrom}/{dateTo}/{userId}")]
        [ProducesDefaultResponseType]
        public IActionResult GetMaintenanceVehicles(DateTime dateFrom, DateTime dateTo, string userId)
        {
            try
            {
                var result = _reportService.GetMaintenanceVehicles(dateFrom, dateTo, userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}