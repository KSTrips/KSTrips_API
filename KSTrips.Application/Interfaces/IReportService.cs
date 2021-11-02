using System;
using System.Collections.Generic;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface IReportService
    {
        List<ReportQty> GetReportQtyByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId);
        List<ReportCost> GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId);
        List<ReportDetail> GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId);
        List<ReportFinancial> GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string userId, int vehicleId);
        ReportDashboard GetDashboardReport(DateTime dateFrom, DateTime dateTo, string userId);
        List<VehiclesMaintenance> GetMaintenanceVehicles (DateTime dateFrom, DateTime dateTo, string userId);
    }
}
