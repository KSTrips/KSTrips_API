using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Domain.Entities
{

    /// <summary>
    /// Entidad que Representa el Viaje
    /// </summary>
    public class Trip
    {
        public int TripId { get; set; }
        public string Origin { get; set; }
        public string Destiny { get; set; }
        public decimal TotalTrip { get; set; }
        public decimal Payment { get; set; }
        public decimal Debt { get; set; }
        public bool ApplyTolls { get; set; }
        public bool ApplyTaxes { get; set; }

        public decimal? TotalProfit { get; set; }

        public virtual Provider Provider { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TripDetail> TripDetails { get; set; }
    }
}
