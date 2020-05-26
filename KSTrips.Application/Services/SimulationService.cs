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
            return await _unitOfWork.CarRepository.GetCarCategories();
        }


        public async Task<List<ExpenseCategory>> GetExpenseCategories()
        {
            return await _unitOfWork.ExpenseRepository.GetExpenseCategories();
        }

        public async Task<List<CarType>> GetCarTypes()
        {
            return await _unitOfWork.CarRepository.GetCarTypes();
        }

        public async Task<List<Toll>> GetTollsByRoute(string origin, string destination)
        {

            return await _unitOfWork.TollRespository.GetTollByRoute(origin, destination);

        }

        public async Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator)
        {
            var tolls = await _unitOfWork.TollRespository.GetTollByRoute(dataSimulator.Origin, dataSimulator.Destination);
            Toll tollResponse = null;

            if (tolls.Count > 0)
                tollResponse = tolls[0];

            var objTransversal = new Transversal();
            var vehicle = new Vehicle();

            vehicle = await _unitOfWork.VehicleRepository.GetVehicleById(dataSimulator.VehicleId);

            var simulationResult = new SimulatorResponse
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
                DiscountIca = (dataSimulator.ApplyIca) ? objTransversal.CalculateIca(dataSimulator.TotalPay) : 0,
                DiscountRetefuente = (dataSimulator.ApplyRetefuente)
                    ? objTransversal.CalculateRetefuente(dataSimulator.TotalPay)
                    : 0,
                DiscountPeajes = (dataSimulator.ApplyTolls)
                    ? objTransversal.CalculateTolls(dataSimulator.CarCategory, tollResponse)
                    : 0,
                DiscountExpenses = objTransversal.CalculateExpenses(dataSimulator.Expenses),
                TotalProfit = objTransversal.CalculateProfit(dataSimulator, tollResponse, dataSimulator.Expenses, dataSimulator.CarCategory)
            };

            simulationResult.GrandTotalExpense = simulationResult.DiscountExpenses + simulationResult.DiscountPeajes
                                                 + simulationResult.DiscountIca + simulationResult.DiscountRetefuente;

            return simulationResult;


        }
    }
}
