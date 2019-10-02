using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips_API.Core.Interfaces;
using KSTrips_API.ViewModels;
using KSTrips_API.ViewModels.Response;

namespace KSTrips_API.Core.Services
{
    public class SimulatorService : ISimulatorService
    {
        private readonly IUnitfOfWork _unitOfWork;
        public SimulatorService(IUnitfOfWork unitOfWork)
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

        public async Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator)
        {
            List<Toll> tolls = await _unitOfWork.TollRespository.GetTollByRoute(dataSimulator.Origin, dataSimulator.Destination);
            Toll tollresponse = null;

            if (tolls.Count > 0)
                tollresponse = tolls[0];

            var transversal = new Transversal();

            var simulationResult = new SimulatorResponse
            {
                Origin = dataSimulator.Origin,
                Destination = dataSimulator.Destination,
                DistanceKM = tollresponse?.DistanceKm ?? 0,
                AproximateTime = tollresponse?.ApproximateTime ?? "00:00",
                QtyTolls = tollresponse?.TotalQtyTolls??0,
                TotalPay = dataSimulator.TotalPay,
                Tolls = tollresponse,
                Expenses = dataSimulator.Expenses,
                Payment = transversal.CalculatePayment(dataSimulator.TotalPay),
                Debt = transversal.CalculateDebt(dataSimulator.TotalPay),
                DiscountOthers = 0,
                DiscountIca = transversal.CalculateIca(dataSimulator.TotalPay),
                DiscountRetefuente = transversal.CalculateRetefuente(dataSimulator.TotalPay),
                DiscountPeajes = transversal.CalculateTolls(dataSimulator.CarCategory, tollresponse),
                DiscountExpenses = transversal.CalculateExpenses(dataSimulator.Expenses),
                TotalProfit = transversal.CalculateProfit(dataSimulator, tollresponse, dataSimulator.Expenses)
            };

            return simulationResult;


        }


    }
}
