using KSTrips.Domain.Transversal.Response;
using System;
using System.Collections.Generic;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IReportRepository
    {
        List<T> GetReportQtyByDates<T>(DateTime dateFrom, DateTime dateTo, int userId,int vehicleId);
        List<T> GetReportExpenseByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId);
        List<T> GetReportDetailByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId);

        List<T> GetReportFinancialByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId);

        ReportDashboard GetDashboardReport(DateTime dateFrom, DateTime dateTo, int userId);
        List<T> GetMaintenanceVehicles<T>(DateTime dateFrom, DateTime dateTo, int userId);
    }
}
