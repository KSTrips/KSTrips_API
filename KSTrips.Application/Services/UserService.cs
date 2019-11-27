using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;

namespace KSTrips.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<User>> GetUsers()
        {
            return await _unitOfWork.UserRepository.GetUsers();
        }

        public async Task<List<User>> GetUserByAuthZeroId(string authZeroId)
        {
            return await _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
        }

        public bool SaveUsers(User dataUsers)
        {
            return  _unitOfWork.UserRepository.SaveUsers(dataUsers);
        }

        public bool UpdateUsers(IEnumerable<User> dataUsers)
        {
            var objDates = new Dates();
            var endDateSubscription = objDates.WorkingDays(30, DateTime.Now);
            foreach (var us in dataUsers)
            {
                if (us.IsActive)
                {
                    us.DateInitSubscription = DateTime.Now;
                    us.DateEndSubscription = endDateSubscription;
                }
                else
                {
                    us.DateInitSubscription = null;
                    us.DateEndSubscription = null;
                }
            }
            return _unitOfWork.UserRepository.UpdateUsers(dataUsers);
        }
    }
}
