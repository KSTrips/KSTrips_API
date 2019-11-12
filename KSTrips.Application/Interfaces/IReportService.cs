using System;
using System.Collections.Generic;
using System.Text;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface IReportService
    {
        List<ReportQty> GetReportQtyByDates(DateTime dateFrom, DateTime dateTo, string authZeroId);
        List<ReportCost> GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string authZeroId);
        List<ReportDetail> GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string authZeroId);
    }
}
