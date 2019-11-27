using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTrips.Infrastructure.Services
{
    public class VehiceRepository : IVehicleRepository
    {

        private TripContext Context { get; }

        public VehiceRepository(TripContext context)
        {
            Context = context;
        }
        public bool SaveVehicles(IEnumerable<Vehicle> vehicle)
        {

            try
            {
                foreach (var vh in vehicle)
                {

                    var existVehicle = Context.Vehicles.Where(ls => ls.LicensePlate == vh.LicensePlate).ToListAsync();

                    if (existVehicle.Result.Count == 0)
                    {
                        vh.DateCreated = DateTime.Now;
                        Context.Vehicles.Add(vh);

                    }
                }

                Context.SaveChanges();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateVehicles(IEnumerable<Vehicle> vehicle)
        {
            try
            {
                foreach (var us in vehicle)
                {
                    //Context.Entry(us).State = EntityState.Modified;
                    us.DateModified = DateTime.Now;

                    Context.Entry(us).Property(p => p.DateModified).IsModified = true;
                    Context.Entry(us).Property(p => p.IsActive).IsModified = true;

                }

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public Task<List<Vehicle>> GetVehiclesByUser(int userId)
        {
            return Context.Vehicles.Where(ls => ls.UserId == userId).ToListAsync();
        }
    }
}
