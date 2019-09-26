using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface ICarCategoryRepository
    {
        Task<List<CarCategory>> GetCarCategories();
    }
}