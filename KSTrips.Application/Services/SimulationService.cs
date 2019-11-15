using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KSTrips.Application.Services
{
    public class SimulationService : ISimulationService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SimulationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarCategory>> GetCarCategories()
        {
            return await _unitOfWork.CarCategoryRepository.GetCarCategories();
        }


        public async Task<List<ExpenseCategory>> GetExpenseCategories()
        {
            return await _unitOfWork.ExpenseRepository.GetExpenseCategories();
        }

        public async Task<List<Toll>> GetTollsByRoute(string origin, string destination)
        {

            return await _unitOfWork.TollRespository.GetTollByRoute(origin, destination);

        }

        public async Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator)
        {
            List<Toll> tolls = await _unitOfWork.TollRespository.GetTollByRoute(dataSimulator.Origin, dataSimulator.Destination);
            Toll tollResponse = null;

            if (tolls.Count > 0)
                tollResponse = tolls[0];

            Transversal objTransversal = new Transversal();

            SimulatorResponse simulationResult = new SimulatorResponse
            {
                Origin = dataSimulator.Origin,
                Destination = dataSimulator.Destination,
                DistanceKM = tollResponse?.DistanceKm ?? 0,
                AproximateTime = tollResponse?.ApproximateTime ?? "00:00",
                QtyTolls = tollResponse?.TotalQtyTolls ?? 0,
                TotalPay = dataSimulator.TotalPay,
                Tolls = tollResponse,
                Expenses = dataSimulator.Expenses,
                Payment = objTransversal.CalculatePayment(dataSimulator.TotalPay),
                Debt = objTransversal.CalculateDebt(dataSimulator.TotalPay),
                DiscountOthers = 0,
                DiscountIca = objTransversal.CalculateIca(dataSimulator.TotalPay),
                DiscountRetefuente = objTransversal.CalculateRetefuente(dataSimulator.TotalPay),
                DiscountPeajes = objTransversal.CalculateTolls(dataSimulator.CarCategory, tollResponse),
                DiscountExpenses = objTransversal.CalculateExpenses(dataSimulator.Expenses),
                TotalProfit = objTransversal.CalculateProfit(dataSimulator, tollResponse, dataSimulator.Expenses)
            };

            return simulationResult;


        }
    }
}
