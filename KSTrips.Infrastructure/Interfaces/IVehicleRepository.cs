using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        bool SaveVehicles(IEnumerable<Vehicle> vehicle);
        bool UpdateVehicles(IEnumerable<Vehicle> vehicle);
        Task<List<Vehicle>> GetVehiclesByUser(int userId);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int vehicleId);
    }
}
