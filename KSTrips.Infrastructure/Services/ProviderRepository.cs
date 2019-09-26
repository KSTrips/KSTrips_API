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
    public class ProviderRepository : IProviderRepository
    {
        private TripContext Context { get; }

        public ProviderRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<Provider>> GetAllProviders()
        {
            return await Context.Providers.ToListAsync( );
        }
    }
}
