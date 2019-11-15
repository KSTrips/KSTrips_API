using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Application.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByAuthZeroId(string authZeroId);
        bool SaveUsers(User dataUsers);
        bool UpdateUsers(IEnumerable<User> dataUsers);

    }
}
