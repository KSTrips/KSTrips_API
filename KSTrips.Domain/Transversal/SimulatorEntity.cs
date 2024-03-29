﻿using System.Collections.Generic;

namespace KSTrips.Domain.Transversal
{
    public class SimulatorEntity
    {

        public int Id { get; set; }
        public List<GeoCoordinates> RouteCoordinates { get; set; }
        public string Provider { get; set; }
        public decimal TotalPay { get; set; }
        public bool ApplyRetefuente { get; set; }
        public bool ApplyIca { get; set; }
        public bool IsUrban { get; set; }
        public List<Expense> Expenses { get; set; }
        public int VehicleId { get; set; }
        public string userEmail { get; set; }
    }
}
