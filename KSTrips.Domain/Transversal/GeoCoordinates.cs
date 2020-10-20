using System;
using System.Collections.Generic;
using System.Text;

namespace KSTrips.Domain.Transversal
{
    public class GeoCoordinates
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool IsOrigin { get; set; }
    }
}
