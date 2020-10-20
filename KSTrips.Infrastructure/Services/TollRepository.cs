using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class TollRepository : ITollRespository
    {
        private TripContext Context { get; }

        public TollRepository(TripContext context)
        {
            Context = context;
        }
        public async Task<List<Toll>> GetTolls()
        {
            return await Context.Tolls.ToListAsync();
        }
    }
}
