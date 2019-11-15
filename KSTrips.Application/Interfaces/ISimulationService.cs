﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;

namespace KSTrips.Application.Interfaces
{
    public interface ISimulationService
    {

        Task<List<ExpenseCategory>> GetExpenseCategories();
        Task<List<CarCategory>> GetCarCategories();
        Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator);
        Task<List<Toll>> GetTollsByRoute(string origin, string destination);

    }
}
