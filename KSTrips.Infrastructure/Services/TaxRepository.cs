using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class TaxRepository : ITaxRepository
    {
        private TripContext Context { get; }

        public TaxRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<Tax>> GetAllTaxes()
        {
            return await Context.Taxes.ToListAsync();
        }

        public async Task<List<Tax>> GetTaxById(int taxId)
        {
            return await Context.Taxes.Where(ls => ls.Id == taxId).ToListAsync();
        }

        public async Task<List<Tax>> GetTaxByName(string taxName)
        {
            return await Context.Taxes.Where(ls => ls.Description == taxName).ToListAsync();
        }
    }
}
