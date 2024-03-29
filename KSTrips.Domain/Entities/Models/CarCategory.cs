﻿using System;

namespace KSTrips.Domain.Entities
{
    public class CarCategory : BaseEntityTrackable
    {
        public string CarTypes { get; set; }
        public decimal? CostAproxByDistance { get; set; }
        public decimal? CostAproxByWeigth { get; set; }
        public string Description { get; set; }
    }
}
