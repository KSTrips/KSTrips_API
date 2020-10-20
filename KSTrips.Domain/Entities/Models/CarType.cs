using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class CarType : BaseEntity
    {
        public string Description { get; set; }

        [ForeignKey("CarCategory")]
        public int CarCategoryId { get; set; }
        public virtual CarCategory CarCategory { get; set; }
    }
}
