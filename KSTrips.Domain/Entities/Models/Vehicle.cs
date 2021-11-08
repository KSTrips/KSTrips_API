using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class Vehicle : BaseEntityTrackable
    {
        public virtual CarCategory CarCategory { get; set; }
        [ForeignKey("CarCategory")]
        public int CarCategoryId { get; set; }
        public string Description { get; set; }
        public string Driver { get; set; }
        public string LicensePlate { get; set; }
        public int NotificationKilometers { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }


    }
}
