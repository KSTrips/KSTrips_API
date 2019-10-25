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

        public async Task<List<ExpenseCategory>> GetExpenseCategories()
        {
            return await Context.ExpenseCategory.ToListAsync();
        }


    }
}
