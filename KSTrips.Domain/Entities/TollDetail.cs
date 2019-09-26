using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que representa el Detalle del Peaje
    /// </summary>
   public class TollDetail
    {
        public int TollDetailId { get; set; }
        public string NameToll { get; set; }
        public decimal? CostCategory1 { get; set; }
        public decimal? CostCategory2 { get; set; }
        public decimal? CostCategory3 { get; set; }
        public decimal? CostCategory4 { get; set; }
        public decimal? CostCategory5 { get; set; }
        public decimal? CostCategory6 { get; set; }
        public decimal? CostCategory7 { get; set; }

        [ForeignKey("Toll")]
        public int TollId { get; set; }
        public virtual  Toll Toll { get; set; }
    }
}
