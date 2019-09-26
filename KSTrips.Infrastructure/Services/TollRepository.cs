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
    public class TollRepository : ITollRespository
    {
        private TripContext Context { get; }

        public TollRepository(TripContext context)
        {
            Context = context;
        }
        public async Task<List<Toll>> GetTollByRoute(string origin, string destiny)
        {
            return await Context.Tolls.Where(ls => ls.Name == origin + " - " + destiny)
                .Include(ls => ls.TollDetails).ToListAsync();
        }
    }
}
