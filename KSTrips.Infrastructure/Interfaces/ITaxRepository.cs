using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface ITaxRepository
    {
        Task<List<Tax>> GetAllTaxes();
    }
}
