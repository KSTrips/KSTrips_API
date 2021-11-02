using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSTrips.Application.Interfaces
{
    public interface ITripService
    {
        Task<List<Trip>> GetTripsByUserId(string userId);
        Task<SimulatorResponse> SaveTrip(SimulatorEntity dataTrip);
        Task<SimulatorResponse> UpdateTrip(SimulatorEntity dataTrip);
        Task<List<Trip>> GetTripById(int tripId);
        Task<bool> UpdateCloseTrip(int tripId);

    }
}
