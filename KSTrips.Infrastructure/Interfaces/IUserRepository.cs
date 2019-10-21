﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByAuthZeroId(string authZeroId);
        bool SaveUsers(User users);
        bool UpdateUsers(IEnumerable<User> users);
    }
}
