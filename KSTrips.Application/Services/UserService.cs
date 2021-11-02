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

        public async Task<List<User>> GetUserByEmail(string email)
        {
            return await _unitOfWork.UserRepository.GetUserByEmail(email);
        }

        public bool SaveUser(User dataUser)
        {
            if (!dataUser.NotificationDays.HasValue)
                dataUser.NotificationDays = 0;

            var user = CalculateNotificationDates(dataUser);
            return _unitOfWork.UserRepository.SaveUsers(dataUser);
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
            var user = CalculateNotificationDates(dataUser);

            Dates objDates = new Dates();
            DateTime endDateSubscription = objDates.WorkingDays(30, DateTime.Now);

            if (user.IsActive)
            {
                user.DateInitSubscription = DateTime.Now;
                user.DateEndSubscription = endDateSubscription;
            }
            else
            {
                user.DateInitSubscription = null;
                user.DateEndSubscription = null;
            }

            return _unitOfWork.UserRepository.UpdateSpecificUser(user);
        }


        private User CalculateNotificationDates(User dataUsers)
        {
            // Calculamos la fecha de notificacion
            Dates objDates = new Dates();
            DateTime dateNotification = objDates.WorkingDays(dataUsers.NotificationDays.Value, DateTime.Now);

            dataUsers.DateforPay = dateNotification;

            return dataUsers;
        }
    }
}
