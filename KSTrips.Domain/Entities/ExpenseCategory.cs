using System;

namespace KSTrips.Domain.Entities
{
    public class ExpenseCategory
    {
        public int ExpenseCategoryId { get; set; }
        public string Description { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }

    }
}
