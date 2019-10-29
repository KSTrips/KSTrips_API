using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;

namespace KSTrips.Application.Services
{
    public class TripService : ITripService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TripService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<SimulatorResponse> SaveTrip(SimulatorEntity dataTrip)
        {
            var objTransversal = new Transversal();
            var simulatorResponse = new SimulatorResponse();

            simulatorResponse = await GenerateResult(dataTrip);

            // Guardamos el proveedor
            var prov = new Provider{ Description = dataTrip.Provider.ToUpper().Trim()};
            var blnProvider = _unitOfWork.ProviderRepository.SaveProvider(prov);
            var user = await _unitOfWork.UserRepository.GetUserByAuthZeroId(dataTrip.UserAuthZeroId);
            var provider = _unitOfWork.ProviderRepository.GetProviderByName(dataTrip.Provider.ToUpper().Trim());


            // Calculamos la fecha de notificacion
            Dates objDates = new Dates();
            var dateNotification = objDates.WorkingDays(user[0].NotificationDays, DateTime.Now);

            if (!blnProvider) return null;

            var trip = new Trip
            {
                Origin = dataTrip.Origin
                ,Destiny = dataTrip.Destination
                ,TotalTrip =  dataTrip.TotalPay
                ,Payment =  simulatorResponse.Payment
                ,Debt = simulatorResponse.Debt
                ,ApplyIca = dataTrip.ApplyIca
                ,ApplyReteFuente = dataTrip.ApplyRetefuente
                ,ApplyTolls =  dataTrip.ApplyTolls
                ,TotalProfit = simulatorResponse.TotalProfit
                ,TripDetails = new List<TripDetail>()
                ,UserId = user[0].UserId
                ,ProviderId = provider.Result[0].ProviderId
                ,CreatedBy = user[0].Name
                ,DateCreated =  DateTime.Now
                ,DateforPay = dateNotification

            };

            // Añadimos los gastos que no son peajes
            foreach (var exp in simulatorResponse.Expenses)
            {
                var tripdetailexpenses = new TripDetail
                {
                    TotalExpense = exp.CostExpense,
                    ExpenseCategoryId = exp.ExpenseCategoryId,
                    IsToll = false,
                    DateCreated = DateTime.Now
                    ,CreatedBy = user[0].Name
                };

                trip.TripDetails.Add(tripdetailexpenses);
            }

            // añadimos el gasto peajes
            var tripdetailTolls = new TripDetail
            {
                TollId = simulatorResponse.Tolls.TollId,
                TotalExpense = objTransversal.CalculateTolls(dataTrip.CarCategory, simulatorResponse.Tolls),
                IsToll = true,
                DateCreated = DateTime.Now
            };

            trip.TripDetails.Add(tripdetailTolls);

            var isSaved = _unitOfWork.TripRepository.SaveTrip(trip);

            return isSaved ? simulatorResponse : null;

        }

        public async Task<SimulatorResponse> UpdateTrip(SimulatorEntity dataTrip)
        {
            var simulatorResponse = new SimulatorResponse();

            simulatorResponse = await GenerateResult(dataTrip);

            return simulatorResponse;
        }

        private async Task<SimulatorResponse> GenerateResult(SimulatorEntity dataTrip)
        {
            var objTransversal = new Transversal();
            var tolls = await _unitOfWork.TollRespository.GetTollByRoute(dataTrip.Origin, dataTrip.Destination);
            Toll tollResponse = null;

            if (tolls.Count > 0)
                tollResponse = tolls[0];

            var simulationResult = new SimulatorResponse
            {
                Origin = dataTrip.Origin,
                Destination = dataTrip.Destination,
                DistanceKM = tollResponse?.DistanceKm ?? 0,
                AproximateTime = tollResponse?.ApproximateTime ?? "00:00",
                QtyTolls = tollResponse?.TotalQtyTolls ?? 0,
                TotalPay = dataTrip.TotalPay,
                Tolls = tollResponse,
                Expenses = dataTrip.Expenses,
                Payment = objTransversal.CalculatePayment(dataTrip.TotalPay),
                Debt = objTransversal.CalculateDebt(dataTrip.TotalPay),
                DiscountOthers = 0,
                DiscountIca = objTransversal.CalculateIca(dataTrip.TotalPay),
                DiscountRetefuente = objTransversal.CalculateRetefuente(dataTrip.TotalPay),
                DiscountPeajes = objTransversal.CalculateTolls(dataTrip.CarCategory, tollResponse),
                DiscountExpenses = objTransversal.CalculateExpenses(dataTrip.Expenses),
                TotalProfit = objTransversal.CalculateProfit(dataTrip, tollResponse, dataTrip.Expenses)
            };

            return simulationResult;
        }
    }
}
