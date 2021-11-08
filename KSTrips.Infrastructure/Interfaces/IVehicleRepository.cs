using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IVehicleRepository
    {
        bool DeleteVehicle(Vehicle vehicle);
        Task<Vehicle> GetVehicleById(int vehicleId);
        Task<Vehicle> GetVehicleByLicensePlate(string licensePlate);
        //bool UpdateVehicles(IEnumerable<Vehicle> vehicle);
        Task<List<Vehicle>> GetVehiclesByUser(int userId);
        bool SaveVehicles(IEnumerable<Vehicle> vehicle);
        bool UpdateVehicle(Vehicle vehicle);
    }
}
