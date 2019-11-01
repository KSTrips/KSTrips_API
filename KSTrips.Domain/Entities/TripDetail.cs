using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Domain.Entities
{
    /// <summary>
    /// Entidad que Representa el Detalle del Viaje
    /// </summary>
    public class TripDetail
    {
        public int TripDetailId { get; set; }
        [ForeignKey("ExpenseCategory")]
        public int ExpenseCategoryId { get; set; }
        public decimal? TotalExpense { get; set; }
        [ForeignKey("Toll")]
        public int TollId { get; set; }
        public bool IsToll { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("Trip")]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
        public virtual List<Tax> Taxes { get;  }

    }
}
