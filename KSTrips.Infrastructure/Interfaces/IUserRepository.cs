using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<List<User>> GetUserByEmail(string email);
        bool SaveUsers(User users);
        bool UpdateUsers(IEnumerable<User> users);
        bool UpdateSpecificUser(User user);

        bool UserExist(string email);
    }
}
