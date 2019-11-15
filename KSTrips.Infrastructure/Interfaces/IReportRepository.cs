using System;
using System.Collections.Generic;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IReportRepository
    {
        List<T> GetReportQtyByDates<T>(DateTime dateFrom, DateTime dateTo, int userId);
        List<T> GetReportExpenseByDates<T>(DateTime dateFrom, DateTime dateTo, int userId);
        List<T> GetReportDetailByDates<T>(DateTime dateFrom, DateTime dateTo, int userId);

        List<T> GetReportFinancialByDates<T>(DateTime dateFrom, DateTime dateTo, int userId);
    }
}
