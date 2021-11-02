using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface ITripRepository
    {
        Task<List<Trip>> GetAllTrips();
        Task<List<Trip>> GetTripsByUserId(int userId);
        Task<List<Trip>> GetTripByRangeDates(DateTime dateFrom, DateTime dateTo);
        Task<List<Trip>> GetTripByTripId(int tripId);

        bool SaveTrip(Trip trip);
        bool UpdateTrip(Trip trip);

        bool UpdateCloseTrip(Trip trip);

    }
}
