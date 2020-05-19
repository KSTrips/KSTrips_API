﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que representa el Detalle del Peaje
    /// </summary>
   public class TollDetail :BaseEntity
    {

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
