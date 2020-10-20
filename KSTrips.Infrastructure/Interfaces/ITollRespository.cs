using KSTrips.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSTrips.Infrastructure.Interfaces
{
   public interface ITollRespository
    {
        Task<List<Toll>> GetTolls();
    }
}
