using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Serialization;

namespace KSTrips.Domain.Transversal.Response
{
    public class ReportQty
    {
        public int QtyTrips { get; set; }
        public int QtyActiveTrips { get; set; }
        public int QtyClosedTrips { get; set; }
    }
}
