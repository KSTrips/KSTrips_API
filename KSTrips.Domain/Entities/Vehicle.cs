using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Description { get; set; }
        public string Driver { get; set; }
        public string LicensePlate { get; set; }

        [ForeignKey("CarCategory")]
        public int CarCategoryId { get; set; }
        public virtual CarCategory CarCategory { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }

    }
}
