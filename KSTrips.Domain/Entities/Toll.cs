using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que representa Los Peajes
    /// </summary>
    public class Toll : BaseEntity
    {

        public int PageId { get; set; }
        public string Name { get; set; }
        public int TotalQtyTolls { get; set; }
        public int DistanceKm { get; set; }
        public string ApproximateTime { get; set; }
        public decimal? TotalCategory1 { get; set; }
        public decimal? TotalCategory2 { get; set; }
        public decimal? TotalCategory3 { get; set; }
        public decimal? TotalCategory4 { get; set; }               
        public decimal? TotalCategory5 { get; set; }
        public decimal? TotalCategory6 { get; set; }
        public decimal? TotalCategory7 { get; set; }

        public virtual  ICollection<TollDetail> TollDetails { get; set; }

    }
}
