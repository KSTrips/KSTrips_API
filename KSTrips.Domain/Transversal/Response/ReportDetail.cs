using System;
using System.Collections.Generic;
using System.Text;
using KSTrips.Domain.Entities;

namespace KSTrips.Domain.Transversal.Response
{
    public class ReportDetail
    {
        public int TripId { get; }
        public int CarCategoryId { get; }
        public string Route { get; }
        public bool IsToll { get; }
        public string CarCategory { get; }
        public int TotalQtyTolls { get; }
        public string Expense { get; }
        public int TotalExpense { get; }
        public string UserName { get; }
        public string ProviderName { get; }
        public DateTime DateCreated { get; }
        public DateTime DateForPay { get; }
    }
}
