using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarCategory>> GetCarCategories();

        Task<List<CarType>> GetCarTypes();
    }
}