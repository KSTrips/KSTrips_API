using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips_API.ViewModels;
using KSTrips_API.ViewModels.Response;

namespace KSTrips_API.Core.Interfaces
{
    public interface ISimulatorService
    {
        Task<List<ExpenseCategory>> GetExpenseCategories();
        Task<List<CarCategory>> GetCarCategories();
        Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator);
    }
}