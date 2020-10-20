using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTrips.Domain.Entities
{
   public class Document : BaseEntity
    {

        public string Description { get; set; }

        [ForeignKey("Trip")]
        public int TripId { get; set; }
    }
}
