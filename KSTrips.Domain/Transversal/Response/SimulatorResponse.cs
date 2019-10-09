using System;
using System.Collections.Generic;
using KSTrips.Domain.Entities;

namespace KSTrips.Domain.Transversal.Response
{
    public class SimulatorResponse
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int DistanceKM { get; set; }
        public int QtyTolls { get; set; }
        public string AproximateTime { get; set; }
        public List<Expense> Expenses { get; set; }
        public Toll Tolls { get; set; }


        public Decimal TotalPay { get; set; }
        public Decimal DiscountRetefuente { get; set; }
        public Decimal DiscountIca { get; set; }
        public Decimal DiscountPeajes { get; set; }
        public Decimal DiscountExpenses { get; set; }
        public Decimal? DiscountOthers { get; set; }
        public Decimal TotalProfit { get; set; }
        public Decimal Debt { get; set; }
        public decimal Payment { get; set; }
    }
}
