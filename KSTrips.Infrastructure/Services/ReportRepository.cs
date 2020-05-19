using Dapper;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KSTrips.Infrastructure.Services
{
    public class ReportRepository : IReportRepository
    {
        private TripContext Context { get; }

        public ReportRepository(TripContext context)
        {
            Context = context;
        }
        public List<T> GetReportQtyByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId)
        {
            try
            {
                System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
                IEnumerable<T> reportQty = connection.Query<T>("EXEC GetQtyReport @dateFrom, @dateTo, @userId, @vehicleId", new { dateFrom, dateTo, userId, vehicleId });

                return reportQty.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<T> GetReportExpenseByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId)
        {
            try
            {
                System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
                IEnumerable<T> reportExp = connection.Query<T>("EXEC GetExpenseReport @dateFrom, @dateTo, @userId, @vehicleId", new { dateFrom, dateTo, userId, vehicleId });

                return reportExp.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<T> GetReportDetailByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId)
        {
            try
            {
                System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
                IEnumerable<T> reportDetail = connection.Query<T>("EXEC GetDetailReport @dateFrom, @dateTo, @userId, @vehicleId", new { dateFrom, dateTo, userId, vehicleId });

                return reportDetail.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<T> GetReportFinancialByDates<T>(DateTime dateFrom, DateTime dateTo, int userId, int vehicleId)
        {
            try
            {
                System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
                IEnumerable<T> reportDetailFinancial = connection.Query<T>("EXEC GetFinancialReport @dateFrom, @dateTo, @userId, @vehicleId", new { dateFrom, dateTo, userId, vehicleId });

                return reportDetailFinancial.ToList();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

    public ReportDashboard GetDashboardReport(DateTime dateFrom, DateTime dateTo, int userId)
    {
        try
        {
            System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
            IEnumerable<ReportDashboard> dashboardReport = connection.Query<ReportDashboard>("EXEC GetDashBoardReport @dateFrom, @dateTo, @userId", new { dateFrom, dateTo, userId });

            return dashboardReport.ToList()[0];
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

        public List<T> GetMaintenanceVehicles<T>(DateTime dateFrom, DateTime dateTo, int userId)
        {
            try
            {
                System.Data.Common.DbConnection connection = Context.Database.GetDbConnection();
                IEnumerable<T> dashboardReport = connection.Query<T>("EXEC GetMaintenanceVehicles @dateFrom, @dateTo, @userId", new { dateFrom, dateTo, userId });

                return dashboardReport.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
