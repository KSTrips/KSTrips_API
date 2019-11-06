using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IReportRepository
    {
        List<T> GetReportQtyByDates<T>(DateTime dateFrom, DateTime dateTo, int userId);
    }
}
