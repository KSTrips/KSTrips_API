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

        public async Task<List<Vehicle>> GetVehiclesByUser(string authZeroId)
        {
            var user = _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
            var userId = user.Result[0].UserId;
            return await _unitOfWork.VehicleRepository.GetVehiclesByUser(userId);
        }

        public bool SaveVehicles(IEnumerable<InComingVehicles> vehicles)
        {
            var NewVehicles = TransformVehicle(vehicles);
            return _unitOfWork.VehicleRepository.SaveVehicles(NewVehicles);
        }

        public bool UpdateVehicles(IEnumerable<InComingVehicles> vehicles)
        {
            var NewVehicles = TransformVehicle(vehicles);
            return _unitOfWork.VehicleRepository.UpdateVehicles(NewVehicles);
        }

        private IEnumerable<Vehicle> TransformVehicle(IEnumerable<InComingVehicles> inComingVehicles)
        {
            return (from us in inComingVehicles
                let user = _unitOfWork.UserRepository.GetUserByAuthZeroId(us.userAuthZeroId)
                let userId = user.Result[0].UserId
                select new Vehicle
                {
                    LicensePlate = us.LicensePlate,
                    Driver = us.Driver,
                    Description = us.Description,
                    UserId = userId,
                    CreatedBy = user.Result[0].Name,
                    DateCreated = DateTime.Now,
                    IsActive = us.IsActive,
                    CarCategoryId = us.CarCategoryId
                }).ToList();
        }
    }
}
