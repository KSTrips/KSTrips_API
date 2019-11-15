using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class CarCategoryRespository : ICarCategoryRepository
    {
        private TripContext Context { get; }

        public CarCategoryRespository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<CarCategory>> GetCarCategories()
        {
            return await Context.CarCategories.ToListAsync();
        }
    }
}
