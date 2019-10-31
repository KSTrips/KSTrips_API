using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface ITripService
    {
        Task<List<Trip>> GetTripsByUserId(string authZeroId);
        Task<SimulatorResponse> SaveTrip(SimulatorEntity dataTrip);
         Task<SimulatorResponse> UpdateTrip(SimulatorEntity dataTrip);
        

    }
}
