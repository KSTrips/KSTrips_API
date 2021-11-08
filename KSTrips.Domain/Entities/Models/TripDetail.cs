using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa el Detalle del Viaje
    /// </summary>
    public class TripDetail : BaseEntityNonTrackable
    {
        public string Comments { get; set; }
        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }
        public bool IsToll { get; set; }
        public virtual IEnumerable<Tax> Taxes { get; }
        [ForeignKey("Toll")]
        public int TollId { get; set; }
        public decimal? TotalExpense { get; set; }
        public virtual Trip Trip { get; set; }
        [ForeignKey("Trip")]
        public int TripId { get; set; }
    }
}
