using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Transversal.Response;
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
            var reportqty =  connection.Query<T>("EXEC GetQtyReport @dateFrom, @dateTo, @userId", new {dateFrom, dateTo, userId});

            return  reportqty.ToList();
        }
    }
}
