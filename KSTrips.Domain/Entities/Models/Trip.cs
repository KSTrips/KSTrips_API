using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{

    /// <summary>
    /// Entidad que Representa el Viaje
    /// </summary>
    public class Trip : BaseEntity
    {

        public bool ApplyIca { get; set; }
        public bool ApplyReteFuente { get; set; }
        public decimal Debt { get; set; }
        public string Destiny { get; set; }
        public bool IsUrban { get; set; }
        public string Origin { get; set; }
        public decimal Payment { get; set; }
        public virtual Provider Provider { get; set; }
        [ForeignKey("Provider")]
        public int ProviderId { get; set; }

        public decimal? TotalProfit { get; set; }
        public decimal TotalTrip { get; set; }
        public virtual ICollection<TripDetail> TripDetails { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        [ForeignKey(("Vehicle"))]
        public int VehicleId { get; set; }
    }
}
