using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que representa Los Peajes
    /// </summary>
    public class Toll : BaseEntity
    {

        public string Via_Code { get; set; }
        public string Name { get; set; }
        public string Territory { get; set; }
        public string Sector { get; set; }
        public string Owner { get; set; }
        public string Location { get; set; }
        public string Road_Sense { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhoneToll { get; set; }
        public string PhoneCrane { get; set; }
        public decimal? CostCategory1 { get; set; }
        public decimal? CostCategory2 { get; set; }
        public decimal? CostCategory3 { get; set; }
        public decimal? CostCategory4 { get; set; }               
        public decimal? CostCategory5 { get; set; }
        public decimal? CostCategory6 { get; set; }
        public decimal? CostCategory7 { get; set; }


    }
}
