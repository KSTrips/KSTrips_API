using System;
using System.Collections.Generic;
using System.Linq;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace KSTrips.Infrastructure.Services
{
    public class ReportRepository : IReportRepository
    {
        private TripContext Context { get; }

        public ReportRepository(TripContext context)
        {
            Context = context;
        }
        public  List<T> GetReportQtyByDates<T>(DateTime dateFrom, DateTime dateTo, int userId)
        {
            var connection = Context.Database.GetDbConnection();
            var reportQty =  connection.Query<T>("EXEC GetQtyReport @dateFrom, @dateTo, @userId", new {dateFrom, dateTo, userId});

            return reportQty.ToList();
        }
        public List<T> GetReportExpenseByDates<T>(DateTime dateFrom, DateTime dateTo, int userId)
        {
            var connection = Context.Database.GetDbConnection();
            var reportExp = connection.Query<T>("EXEC GetExpenseReport @dateFrom, @dateTo, @userId", new { dateFrom, dateTo, userId });

            return reportExp.ToList();
        }
        public List<T> GetReportDetailByDates<T>(DateTime dateFrom, DateTime dateTo, int userId)
        {
            var connection = Context.Database.GetDbConnection();
            var reportDetail = connection.Query<T>("EXEC GetDetailReport @dateFrom, @dateTo, @userId", new { dateFrom, dateTo, userId });

            return reportDetail.ToList();
        }
        public List<T> GetReportFinancialByDates<T>(DateTime dateFrom, DateTime dateTo, int userId)
        {
            var connection = Context.Database.GetDbConnection();
            var reportDetail = connection.Query<T>("EXEC GetFinancialReport @dateFrom, @dateTo, @userId", new { dateFrom, dateTo, userId });

            return reportDetail.ToList();
        }
    }
}
