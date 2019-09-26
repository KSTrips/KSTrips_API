using KSTrips.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KSTrips.Infrastructure.Interfaces
{
   public interface ITollRespository
    {
        Task<List<Toll>> GetTollByRoute(string origin, string destiny);
    }
}
