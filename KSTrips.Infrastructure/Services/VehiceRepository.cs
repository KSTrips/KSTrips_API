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
                foreach (Vehicle vh in vehicle)
                {

                    Task<List<Vehicle>> existVehicle = Context.Vehicles.Where(ls => ls.LicensePlate == vh.LicensePlate).ToListAsync();

                    if (existVehicle.Result.Count == 0)
                    {
                        vh.DateCreated = DateTime.Now;
                        Context.Vehicles.Add(vh);
                    }
                    else
                    {
                        return false;
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
                foreach (Vehicle us in vehicle)
                {
                    Context.Attach(us).State = EntityState.Modified;
                    us.DateModified = DateTime.Now;

                    Context.Attach(us).Property(p => p.DateModified).IsModified = true;
                    Context.Attach(us).Property(p => p.IsActive).IsModified = true;
                    Context.Attach(us).Property(p => p.Driver).IsModified = true;
                    Context.Attach(us).Property(p => p.NotificationKilometers).IsModified = true;

                }

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public bool UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                vehicle.DateModified = DateTime.Now;
                Context.Entry(vehicle).State = EntityState.Modified;

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeleteVehicle(Vehicle vehicle)
        {
            try
            {
                Context.Attach(vehicle).State = EntityState.Deleted;
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
            return Context.Vehicles.Where(ls => ls.UserId == userId)
                .ToListAsync();
        }

        public Task<Vehicle> GetVehicleById(int vehicleId)
        {
            return Context.Vehicles.Where(ls => ls.Id == vehicleId).FirstOrDefaultAsync();
        }
    }
}
