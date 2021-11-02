using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                .Include(ls => ls.TripDetails)
                .Include(ls => ls.Vehicle)
                .ToListAsync();
        }

        public async Task<List<Trip>> GetTripsByUserId(int userId)
        {
            return await Context.Trips.Where(ls => ls.UserId == userId)
                .Include(ls => ls.Provider)
                .Include(lc => lc.TripDetails)
                .Include(ls => ls.Vehicle)
                .ToListAsync();

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
            catch (Exception)
            {
                return false;
            }

        }

        public bool UpdateTrip(Trip trip)
        {
            try
            {
                trip.DateModified= DateTime.Now;
                
                Context.Attach(trip).State = EntityState.Modified;
                Context.Attach(trip).Property(p => p.DateModified).IsModified = true;
                Context.Attach(trip).Property(p => p.TotalProfit).IsModified = true;
                Context.Attach(trip).Property(p => p.ApplyIca).IsModified = true;
                Context.Attach(trip).Property(p => p.ApplyReteFuente).IsModified = true;

                Context.Attach(trip).Property(p => p.IsActive).IsModified = true;

                foreach (var tripDet in trip.TripDetails)
                {
                    tripDet.DateModified = DateTime.Now;
                    Context.Entry(tripDet).Property(p => p.DateModified).IsModified = true;
                    Context.Entry(tripDet).Property(p => p.TotalExpense).IsModified = true;
                    Context.Entry(tripDet).Property(p => p.Comments).IsModified = true;
                }

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateCloseTrip(Trip trip)
        {
            try
            {
                trip.DateModified = DateTime.Now;

                Context.Entry(trip).State = EntityState.Modified;


                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        public async Task<List<Trip>> GetTripByTripId(int tripId)
        {
            return await Context.Trips.Where(ls => ls.Id == tripId)
                .Include(ls => ls.Provider)
                .Include(lc => lc.TripDetails)
                .Include(ls => ls.Vehicle)
                .ToListAsync();
        }
    }
}
