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
            Toll tollResponse = null;

            if (tolls.Count > 0)
                tollResponse = tolls[0];

            var objTransversal = new Transversal();

            var simulationResult = new SimulatorResponse
            {
                Origin = dataSimulator.Origin,
                Destination = dataSimulator.Destination,
                DistanceKM = tollResponse?.DistanceKm ?? 0,
                AproximateTime = tollResponse?.ApproximateTime ?? "00:00",
                QtyTolls = tollResponse?.TotalQtyTolls??0,
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
