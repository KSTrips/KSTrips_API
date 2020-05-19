using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return _unitOfWork.UserRepository.SaveUsers(dataUsers);
        }

        public bool UpdateUsers(IEnumerable<User> dataUsers)
        {
            Dates objDates = new Dates();
            DateTime endDateSubscription = objDates.WorkingDays(30, DateTime.Now);
            foreach (User us in dataUsers)
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

        public bool UpdateSpecificUser(User dataUser)
        {
            Dates objDates = new Dates();
            DateTime endDateSubscription = objDates.WorkingDays(30, DateTime.Now);

            if (dataUser.IsActive)
            {
                dataUser.DateInitSubscription = DateTime.Now;
                dataUser.DateEndSubscription = endDateSubscription;
            }
            else
            {
                dataUser.DateInitSubscription = null;
                dataUser.DateEndSubscription = null;
            }

            return _unitOfWork.UserRepository.UpdateSpecificUser(dataUser);
        }

    }
}
