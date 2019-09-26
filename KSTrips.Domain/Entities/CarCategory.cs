using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Domain.Entities
{
    public class CarCategory
    {
        public int CarCategoryId { get; set; }
        public string Description { get; set; }
        public string CarTypes { get; set; }
        public decimal? CostAproxByDistance { get; set; }
        public decimal? CostAproxByWeigth { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
