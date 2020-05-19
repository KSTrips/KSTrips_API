using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa el Detalle del Viaje
    /// </summary>
    public class TripDetail : BaseEntity
    {

        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }
        public decimal? TotalExpense { get; set; }
        [ForeignKey("Toll")]
        public int TollId { get; set; }
        public bool IsToll { get; set; }
        public string Comments { get; set; }
        [ForeignKey("Trip")]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public virtual IEnumerable<Tax> Taxes { get;  }

    }
}
