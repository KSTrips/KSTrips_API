using System;
using System.Collections.Generic;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface IReportService
    {
        List<ReportQty> GetReportQtyByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId);
        List<ReportCost> GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId);
        List<ReportDetail> GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId);
        List<ReportFinancial> GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string authZeroId, int vehicleId);
        ReportDashboard GetDashboardReport(DateTime dateFrom, DateTime dateTo, string authZeroId);
        List<VehiclesMaintenance> GetMaintenanceVehicles (DateTime dateFrom, DateTime dateTo, string authZeroId);
    }
}
