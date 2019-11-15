using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class TripRepository : ITripRepository
    {
        private TripContext Context { get; }

        public TripRepository(TripContext context)
        {
            Context = context;
        }
        public async Task<List<Trip>> GetAllTrips()
        {
            return await Context.Trips.ToListAsync();
        }

        public async Task<List<Trip>> GetTripByRangeDates(DateTime dateFrom, DateTime dateTo)
        {
            return await Context.Trips.Where(ls => ls.DateCreated >= dateFrom && ls.DateCreated <= dateTo)
                .Include(ls => ls.Provider)
                .Include(ls => ls.TripDetails).ToListAsync();
        }

        public async Task<List<Trip>> GetTripsByUserId(int userId)
        {
            return await Context.Trips.Where(ls => ls.UserId == userId)
                .Include(ls => ls.Provider)
                .Include(lc => lc.TripDetails).ToListAsync();
        }

        public bool SaveTrip(Trip trip)
        {
            try
            {
                trip.IsActive = true;
                Context.Trips.Add(trip);
                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public bool UpdateTrip(Trip trip)
        {
            throw new NotImplementedException();
        }
    }
}
