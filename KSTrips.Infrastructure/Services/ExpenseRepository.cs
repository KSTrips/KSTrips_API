using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class ExpenseRepository : IExpenseRepository
    {
        private TripContext Context { get; }

        public ExpenseRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<Expense>> GetAllExpenses()
        {
            return await Context.Expenses.ToListAsync();
        }

        public async Task<List<ExpenseCategory>> GetExpenseCategories()
        {
            return await Context.ExpenseCategory.ToListAsync();
        }
        public async Task<List<Expense>> GetExpensesByTripDetailId(int tripDetailId)
        {
            return await Context.Expenses.Where(ls => ls.TripDetailId == tripDetailId).ToListAsync();
        }


    }
}
