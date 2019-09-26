using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<ExpenseCategory>> GetExpenseCategories();
        Task<List<Expense>> GetAllExpenses();
        Task<List<Expense>> GetExpensesByTripDetailId(int tripDetailId);

    }
}
