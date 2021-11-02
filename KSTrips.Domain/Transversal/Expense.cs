using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KSTrips.Domain.Transversal
{
    /// <summary>
    /// Entidad que Representa los Gastos
    /// </summary>
    public class Expense
    {
        public string Description { get; set; }
        public decimal CostExpense { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

        [NotMapped]
        public string Comments { get; set; }
        public int ExpenseCategoryId { get; set; }
        public int TripDetailId { get; set; }


    }
}
