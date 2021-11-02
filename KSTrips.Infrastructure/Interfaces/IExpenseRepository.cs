using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<ExpenseCategory>> GetExpenseCategories();


    }
}
