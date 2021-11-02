using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<SimulatorResponse> SimulateTripAsync(SimulatorEntity dataSimulator)
        {
            var tolls = await _unitOfWork.TollRespository.GetTolls();
            Toll tollResponse = new Toll();

            if (tolls.Count > 0)
                tollResponse = tolls[0];

            var objTransversal = new Transversal(_unitOfWork);
            var vehicle = new Vehicle();


            var distance = objTransversal.GetDistance(dataSimulator.RouteCoordinates.Where(ls=> ls.IsOrigin).Select(ls => ls).FirstOrDefault(), dataSimulator.RouteCoordinates.Where(ls => !ls.IsOrigin).Select(ls => ls).FirstOrDefault());
            var tollsss = objTransversal.GetTollsByRoute(dataSimulator.RouteCoordinates);

            vehicle = await _unitOfWork.VehicleRepository.GetVehicleById(dataSimulator.VehicleId);

            var simulationResult = new SimulatorResponse
            {
                Origin = dataSimulator.RouteCoordinates.Where(ls => ls.IsOrigin).Select(ls=>ls.Name).FirstOrDefault(),
                Destination = dataSimulator.RouteCoordinates.Where(ls => ls.IsOrigin == false).Select(ls => ls.Name).FirstOrDefault(),
                //DistanceKM = tollResponse?.DistanceKm ?? 0,
                //AproximateTime = tollResponse?.ApproximateTime ?? "00:00",
                //QtyTolls = tollResponse?.TotalQtyTolls ?? 0,
                TotalPay = dataSimulator.TotalPay,
                Tolls = tollResponse,
                Expenses = dataSimulator.Expenses,
                Payment = objTransversal.CalculatePayment(dataSimulator.TotalPay),
                Debt = objTransversal.CalculateDebt(dataSimulator.TotalPay),
                DiscountOthers = objTransversal.CalculateDocuments(dataSimulator.TotalPay) + objTransversal.CalculateOtherInsurance(dataSimulator.TotalPay),
                DiscountIca = (dataSimulator.ApplyIca) ? objTransversal.CalculateIca(dataSimulator.TotalPay) : 0,
                DiscountRetefuente = (dataSimulator.ApplyRetefuente)
                    ? objTransversal.CalculateRetefuente(dataSimulator.TotalPay)
                    : 0,
                //DiscountPeajes = (dataSimulator.ApplyTolls)
                //    ? objTransversal.CalculateTolls(dataSimulator.CarCategory, tollResponse)
                //    : 0,
                DiscountExpenses = objTransversal.CalculateExpenses(dataSimulator.Expenses),
                TotalProfit = objTransversal.CalculateProfit(dataSimulator, tollResponse)
            };

            simulationResult.GrandTotalExpense = simulationResult.DiscountExpenses + simulationResult.DiscountPeajes
                                                 + simulationResult.DiscountIca + simulationResult.DiscountRetefuente;

            return simulationResult;


        }
    }
}
