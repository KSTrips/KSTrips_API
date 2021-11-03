namespace KSTrips.Domain.Transversal.Response
{
    public class ReportDashboard
    {
        public int QtyTrips { get; }
        public int QtyActiveTrips { get; }
        public int QtyClosedTrips { get; }
        public decimal Revenue { get; }
        public decimal Expenses { get; }
        public decimal OutstandingBalance { get; }
        public decimal Profit { get; }
        public decimal IcaTax { get; }
        public decimal RetefuenteTax { get; }
        public decimal AccountBalance { get; }
        public decimal Kilometers { get; }

    }
}
