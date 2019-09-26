using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using Microsoft.Extensions.ObjectPool;

namespace KSTrips_API.ViewModels
{
    public class SimulatorEntity
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Provider { get; set; }
        public decimal TotalPay { get; set; }
        public bool ApplyRetefuente { get; set; }
        public bool ApplyIca { get; set; }
        public bool ApplyTolls { get; set; }
        public List<Expense> Expenses { get; set; }
        public int CarCategory { get; set; }
    }
}
