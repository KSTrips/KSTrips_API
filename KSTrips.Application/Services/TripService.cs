﻿using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTrips.Application.Services
{
    public class TripService : ITripService
    {

        private readonly IUnitOfWork _unitOfWork;
        public TripService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Trip>> GetTripsByUserId(string authZeroId)
        {
            Task<List<User>> user = _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
            int userId = user.Result[0].Id;
            List<Trip> result = await _unitOfWork.TripRepository.GetTripsByUserId(userId);
            return result;
        }

        public async Task<List<Trip>> GetTripById(int tripId)
        {
            List<Trip> result = await _unitOfWork.TripRepository.GetTripByTripId(tripId);
            return result;
        }

        public async Task<SimulatorResponse> SaveTrip(SimulatorEntity dataTrip)
        {

            SimulatorResponse simulatorResponse = new SimulatorResponse();

            simulatorResponse = await GenerateResult(dataTrip);

            // Guardamos el proveedor
            Provider prov = new Provider { Description = dataTrip.Provider.ToUpper().Trim() };
            bool blnProvider = _unitOfWork.ProviderRepository.SaveProvider(prov);
            List<User> user = await _unitOfWork.UserRepository.GetUserByAuthZeroId(dataTrip.UserAuthZeroId);

            if (!blnProvider) return null;

            // Transformamos la data que llega de la GUI
            Trip trip = await TransformTrip(dataTrip, simulatorResponse, user[0]);

            bool isSaved = _unitOfWork.TripRepository.SaveTrip(trip);

            return isSaved ? simulatorResponse : null;

        }

        public async Task<SimulatorResponse> UpdateTrip(SimulatorEntity dataTrip)
        {
            SimulatorResponse simulatorResponse = new SimulatorResponse();
            List<User> user = await _unitOfWork.UserRepository.GetUserByAuthZeroId(dataTrip.UserAuthZeroId);

            simulatorResponse = await GenerateResult(dataTrip);

            // Transformamos la data que llega de la GUI
            Trip trip =await TransformTrip(dataTrip, simulatorResponse, user[0]);

            bool isUpdated = _unitOfWork.TripRepository.UpdateTrip(trip);

            return isUpdated ? simulatorResponse : null;

        }

        public async Task<bool> UpdateCloseTrip(int tripId)
        {
            bool isUpdated = false;
            List<Trip> trip = await _unitOfWork.TripRepository.GetTripByTripId(tripId);

            if (trip.Count > 0)
            {
                trip[0].Debt = 0;
                trip[0].IsActive = false;
                isUpdated = _unitOfWork.TripRepository.UpdateCloseTrip(trip[0]);
            }
            return isUpdated ;

        }

        private async Task<SimulatorResponse> GenerateResult(SimulatorEntity dataTrip)
        {
            try
            {
                Transversal objTransversal = new Transversal();
                List<Toll> tolls = await _unitOfWork.TollRespository.GetTollByRoute(dataTrip.Origin, dataTrip.Destination);
                Toll tollResponse = null;

                if (tolls.Count > 0)
                    tollResponse = tolls[0];

                Vehicle vehicle = new Vehicle();
                vehicle = await _unitOfWork.VehicleRepository.GetVehicleById(dataTrip.VehicleId);

                SimulatorResponse simulationResult = new SimulatorResponse
                {
                    Origin = dataTrip.Origin,
                    Destination = dataTrip.Destination,
                    DistanceKM = tollResponse?.DistanceKm ?? 0,
                    AproximateTime = tollResponse?.ApproximateTime ?? "00:00",
                    QtyTolls = tollResponse?.TotalQtyTolls ?? 0,
                    TotalPay = dataTrip.TotalPay,
                    Tolls = tollResponse,

                    Expenses = dataTrip.Expenses ?? new List<Expense>(),

                    Payment = objTransversal.CalculatePayment(dataTrip.TotalPay),
                    Debt = objTransversal.CalculateDebt(dataTrip.TotalPay),
                    DiscountOthers = 0,
                    DiscountIca = (dataTrip.ApplyIca) ? objTransversal.CalculateIca(dataTrip.TotalPay) : 0,
                    DiscountRetefuente = (dataTrip.ApplyRetefuente) ? objTransversal.CalculateRetefuente(dataTrip.TotalPay) : 0,
                    DiscountPeajes = (dataTrip.ApplyTolls) ? objTransversal.CalculateTolls(vehicle.CarCategoryId, tollResponse) : 0,
                    DiscountExpenses = objTransversal.CalculateExpenses(dataTrip.Expenses),
                    TotalProfit = objTransversal.CalculateProfit(dataTrip, tollResponse, dataTrip.Expenses, vehicle.CarCategoryId)
                };

                simulationResult.GrandTotalExpense = simulationResult.DiscountExpenses + simulationResult.DiscountPeajes
                                                                                       + simulationResult.DiscountIca + simulationResult.DiscountRetefuente;

                return simulationResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private async Task<Trip> TransformTrip(SimulatorEntity dataTrip, SimulatorResponse simulatorResponse, User user)
        {
            Transversal objTransversal = new Transversal();
            List<Trip> tripDB = new List<Trip>();
            // Calculamos la fecha de notificacion
            Dates objDates = new Dates();
            DateTime dateNotification = objDates.WorkingDays(user.NotificationDays, DateTime.Now);
            Task<List<Provider>> provider = _unitOfWork.ProviderRepository.GetProviderByName(dataTrip.Provider.ToUpper().Trim());
            Vehicle vehicle = new Vehicle();
            vehicle = await _unitOfWork.VehicleRepository.GetVehicleById(dataTrip.VehicleId);

            int tripDetailIdToll = 0;
            if (simulatorResponse.Expenses.Count == 0)
            {
                tripDetailIdToll = 0;
            }
            else if (simulatorResponse.Expenses.Select(ls => ls.TripDetailId).First() != 0)
            {
                tripDetailIdToll = simulatorResponse.Expenses.Where(ls => ls.ExpenseCategoryId == 0).Select(ls => ls.TripDetailId).First();
            }


            Trip trip = new Trip
            {
                Id = dataTrip.Id != -1 ? dataTrip.Id : 0,
                Origin = dataTrip.Origin,
                Destiny = dataTrip.Destination,
                TotalTrip = dataTrip.TotalPay,
                Payment = simulatorResponse.Payment,
                Debt = simulatorResponse.Debt,
                ApplyIca = dataTrip.ApplyIca,
                ApplyReteFuente = dataTrip.ApplyRetefuente,
                ApplyTolls = dataTrip.ApplyTolls,
                TotalProfit = simulatorResponse.TotalProfit,
                TripDetails = new List<TripDetail>(),
                UserId = user.Id,
                ProviderId = provider.Result[0].Id,
                CreatedBy = user.Name,
                DateCreated = DateTime.Now,
                DateforPay = dateNotification,
                VehicleId = dataTrip.VehicleId
            };

            // Añadimos los gastos que no son peajes
            foreach (Expense exp in simulatorResponse.Expenses)
            {
                if (exp.ExpenseCategoryId != 0)
                {
                    TripDetail tripdetailexpenses = new TripDetail
                    {
                        Id = exp.TripDetailId,
                        TotalExpense = exp.CostExpense,
                        ExpenseCategoryId = exp.ExpenseCategoryId,
                        IsToll = false,
                        DateCreated = DateTime.Now,
                        CreatedBy = user.Name,
                        Comments = exp.Comments, 
                        TripId = trip.Id
                    };
                    trip.TripDetails.Add(tripdetailexpenses);
                }



            }

            if (simulatorResponse.Tolls != null)
            {
                // añadimos el gasto peajes
                TripDetail tripdetailTolls = new TripDetail
                {
                    Id = tripDetailIdToll,
                    TollId = simulatorResponse.Tolls.Id,
                    TotalExpense = objTransversal.CalculateTolls(vehicle.CarCategoryId, simulatorResponse.Tolls),
                    IsToll = true,
                    DateCreated = DateTime.Now,
                    CreatedBy = user.Name,
                    TripId = trip.Id
                };

                trip.TripDetails.Add(tripdetailTolls);
            }

            

            return trip;
        }
    }
}
