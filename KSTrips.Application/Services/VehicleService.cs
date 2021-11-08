using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTrips.Application.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IUnitOfWork _unitOfWork;
        public VehicleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Vehicle>> GetVehiclesByUser(string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return await _unitOfWork.VehicleRepository.GetVehiclesByUser(userId);
        }
        public async Task<Vehicle> GetVehicleByLicensePlate(string licensePlate)
        {
            return await _unitOfWork.VehicleRepository.GetVehicleByLicensePlate(licensePlate);
        }

        public bool SaveVehicles(IEnumerable<InComingVehicles> vehicles)
        {
            var NewVehicles = TransformVehicle(vehicles);
            return _unitOfWork.VehicleRepository.SaveVehicles(NewVehicles);
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            return _unitOfWork.VehicleRepository.UpdateVehicle(vehicle);
        }

        public bool DeleteVehicle(Vehicle vehicle)
        {
            return _unitOfWork.VehicleRepository.DeleteVehicle(vehicle);
        }

        private IEnumerable<Vehicle> TransformVehicle(IEnumerable<InComingVehicles> inComingVehicles )
        {
            return (from us in inComingVehicles
                let user = _unitOfWork.UserRepository.GetUserByEmail(us.Email)
                let userId = user.Result[0].Id
                select new Vehicle
                {
                    LicensePlate = us.LicensePlate,
                    Driver = us.Driver,
                    Description = us.Description,
                    NotificationKilometers = us.NotificationKilometers,
                    UserId = userId,
                    CreatedBy = user.Result[0].UserName,
                    DateCreated = DateTime.Now,
                    IsActive = us.IsActive,
                    CarCategoryId = us.CarCategoryId
                }).ToList();
        }
    }
}
