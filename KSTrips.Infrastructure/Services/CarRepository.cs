using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class CarRepository : ICarRepository
    {
        private TripContext Context { get; }

        public CarRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<CarCategory>> GetCarCategories()
        {
            return await Context.CarCategories.ToListAsync();
        }

        public async Task<List<CarType>> GetCarTypes()
        {
            return await Context.carTypes.ToListAsync();

            
        }
    }
}
