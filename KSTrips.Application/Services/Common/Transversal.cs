using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;
using KSTrips.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KSTrips.Application.Services
{
    public class Transversal
    {
        private readonly IUnitOfWork _unitOfWork;
        private int icaTax;
        private int reteFuenteTax;
        private int documentTax;
        private int otherTax;
        private int abono;
        private List<Tax> taxes;
        private List<CarCategory> carCategories;
        private const double EarthRadius = 6371;
        private double km;

        public Transversal(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            var alltaxes = _unitOfWork.TaxRepository.GetAllTaxes();
            var allCarCategories = _unitOfWork.CarRepository.GetCarCategories();

            taxes = alltaxes.Result.ToList();
            carCategories = allCarCategories.Result.ToList();
        }

        /// <summary>
        /// Metodo que calcula el abono del flete  ya sea del (65 - 70 - 80 /100) = % de abono
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculatePayment(decimal totalPay)
        {
            abono = (int)taxes.Where(ls => ls.Description.Contains("Abono")).Select(ls => ls.CostTax).FirstOrDefault();
            decimal payment = totalPay * abono / 100;
            return payment;
        }

        /// <summary>
        /// Metodo que calcula el restante el saldo pendiente a cobrar
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateDebt(decimal totalPay)
        {
            decimal ica = CalculateIca(totalPay);
            decimal retefuente = CalculateRetefuente(totalPay);
            decimal payment = CalculatePayment(totalPay);
            decimal debt = totalPay - payment - ica - retefuente;
            return debt;
        }

        /// <summary>
        /// metodo que calcula el descuento de ica por 8/1000 = 0.008%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateIca(decimal totalPay)
        {
            icaTax = (int)taxes.Where(ls => ls.Description.Contains("Ica")).Select(ls => ls.CostTax).FirstOrDefault();
            decimal discountIca = totalPay * icaTax / 1000;
            return discountIca;
        }

        /// <summary>
        /// Metodo que calcula el descuento de retefuente 1/100  = 1%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateRetefuente(decimal totalPay)
        {
            reteFuenteTax = (int)taxes.Where(ls => ls.Description.Contains("Retefuente")).Select(ls => ls.CostTax).FirstOrDefault();
            decimal discountRetefuente = totalPay * reteFuenteTax / 100;
            return discountRetefuente;
        }

        /// <summary>
        /// Metodo que calcular el descuento de papeleria 4/1000 = 0.004%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateDocuments(decimal totalPay)
        {
            documentTax = (int)taxes.Where(ls => ls.Description.Contains("Papeleria")).Select(ls => ls.CostTax).FirstOrDefault();
            decimal discountRetefuente = totalPay * documentTax / 1000;
            return discountRetefuente;
        }

        /// <summary>
        /// Metodo que calcular el descuento de otros seguros 3/1000 = 0.003%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateOtherInsurance(decimal totalPay)
        {
            otherTax = (int)taxes.Where(ls => ls.Description.Contains("Otros")).Select(ls => ls.CostTax).FirstOrDefault();
            decimal discountRetefuente = totalPay * otherTax / 1000;
            return discountRetefuente;
        }

        /// <summary>
        /// Metodo que calcula los gastos del viaje
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public decimal CalculateExpenses(List<Expense> expenses)
        {
            decimal sumexpenses = expenses.Where(ls => ls.ExpenseCategoryId != 0).Sum(ls => ls.CostExpense);
            return sumexpenses;
        }

        /// <summary>
        /// Metodo que calcula el total de los peajes
        /// </summary>
        /// <param name="category"></param>
        /// <param name="tolls"></param>
        /// <returns></returns>
        public decimal CalculateTolls(int? category, Toll tolls)
        {

            decimal sumTolls = 0;

            if (tolls == null)
                return sumTolls;

            switch (category)
            {
                case 1:
                    if (tolls.CostCategory1 != null) sumTolls = (decimal)tolls.CostCategory1;
                    break;
                case 2:
                    if (tolls.CostCategory2 != null) sumTolls = (decimal)tolls.CostCategory2;
                    break;
                case 3:
                    if (tolls.CostCategory3 != null) sumTolls = (decimal)tolls.CostCategory3;
                    break;
                case 4:
                    if (tolls.CostCategory4 != null) sumTolls = (decimal)tolls.CostCategory4;
                    break;
                case 5:
                    if (tolls.CostCategory5 != null) sumTolls = (decimal)tolls.CostCategory5;
                    break;
                case 6:
                    if (tolls.CostCategory6 != null) sumTolls = (decimal)tolls.CostCategory6;
                    break;
                case 7:
                    if (tolls.CostCategory7 != null) sumTolls = (decimal)tolls.CostCategory7;
                    break;
                default:
                    break;

            }

            return sumTolls;
        }

        /// <summary>
        /// Metodo que calcula la ganancia del viaje
        /// </summary>
        /// <param name="dataSimulator"></param>
        /// <param name="_tolls"></param>
        /// <param name="_expenses"></param>
        /// <param name="_category"></param>
        /// <returns></returns>
        public decimal CalculateProfit(SimulatorEntity dataSimulator, Toll _tolls)
        {
            decimal ica = CalculateIca(dataSimulator.TotalPay);
            decimal retefuente = CalculateRetefuente(dataSimulator.TotalPay);
            int _category = _unitOfWork.VehicleRepository.GetVehicleById(dataSimulator.VehicleId).Result.CarCategoryId;
            decimal tolls = CalculateTolls(_category, _tolls);
            decimal expenses = CalculateExpenses(dataSimulator.Expenses);

            decimal profit = dataSimulator.TotalPay - ica - retefuente - tolls - expenses;
            return profit;
        }

        public double GetDistance(GeoCoordinates point1, GeoCoordinates point2)
        {
            double distance = 0;
            try
            {
                double Lat = (point2.Latitude - point1.Latitude) * (Math.PI / 180);
                double Lon = (point2.Longitude - point1.Longitude) * (Math.PI / 180);
                double a = Math.Sin(Lat / 2) * Math.Sin(Lat / 2) + Math.Cos(point1.Latitude * (Math.PI / 180)) * Math.Cos(point2.Latitude * (Math.PI / 180)) * Math.Sin(Lon / 2) * Math.Sin(Lon / 2);
                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
                distance = EarthRadius * c;

                km = distance / 1000;
            }
            catch (Exception ex)
            {

            }
            return distance;
        }

        public List<GeoCoordinates> GetTollsByRoute(List<GeoCoordinates> Ruta)
        {
            GeoCoordinates Punto1;
            GeoCoordinates Punto2;
            double RadioLat = 0;
            var Peajes = _unitOfWork.TollRespository.GetTolls().Result.ToList();
            var ListPeajes = new List<GeoCoordinates>();
            int countPeaje = 0;
            try
            {

                //  for (var d = 0; d < Ruta.Count - 1; d++)
                // {
                Punto1 = Ruta[0];
                Punto2 = Ruta[1];
                var mAbs = Math.Abs((Punto2.Longitude - Punto1.Longitude) / (Punto2.Latitude - Punto1.Latitude));
                double RadioLng = 0;
                if (mAbs > 1)
                {
                    RadioLat = 0.002;
                    RadioLng = 0;
                }
                else
                {
                    RadioLat = 0;
                    RadioLng = 0.002;
                }
                double RadioMasLat = (Math.Max(Punto1.Latitude, Punto2.Latitude)) + RadioLat;
                double RadioMenosLat = (Math.Min(Punto1.Latitude, Punto2.Latitude)) - RadioLat;
                double RadioMasLng = (Math.Max(Punto1.Longitude, Punto2.Longitude)) + RadioLng;
                double RadioMenosLng = (Math.Min(Punto1.Longitude, Punto2.Longitude)) - RadioLng;



                for (var p = 0; p < Peajes.Count; p++)
                {
                    if (RadioMenosLat < Peajes[p].Latitude && Peajes[p].Latitude < RadioMasLat)
                    {
                        if (RadioMenosLng < Peajes[p].Longitude && Peajes[p].Longitude < RadioMasLng)
                        {
                            bool flag = false;
                            if (ListPeajes.Count > 0)
                            {
                                if (Peajes[p].Name == ListPeajes[countPeaje - 1].Name) { flag = true; }
                            }

                            //if (Peajes[p].Road_Sense == "Ambos")
                            //{
                            if (flag == false)
                            {
                                ListPeajes.Add(new GeoCoordinates { IsOrigin = false, Latitude = Peajes[p].Latitude, Longitude = Peajes[p].Longitude, Name = Peajes[p].Name });
                                countPeaje += 1;
                            }
                            //}
                            //else
                            //{
                            //    var Sentido = CalcularSentido(Punto1, Punto2);
                            //    if (Sentido == Peajes[p].Road_Sense)
                            //    {
                            //        if (flag == false)
                            //        {
                            //            ListPeajes.Add(new GeoCoordinates { IsOrigin = false, Latitude = Peajes[p].Latitude, Longitude = Peajes[p].Longitude, Name = Peajes[p].Name });
                            //            countPeaje += 1;
                            //        }
                            //    }
                            //}
                            // break;
                        }
                    }
                }
                //  }
            }
            catch (Exception ex)
            {

            }

            return ListPeajes.OrderByDescending(ls => ls.Latitude).ToList();
        }

        private string CalcularSentido(GeoCoordinates Punto1, GeoCoordinates Punto2)
        {
            var Sentido = "";

            if (Punto1.Latitude <= Punto2.Latitude)
            {
                Sentido = "Nor";
            }
            else
            {
                Sentido = "Sur";
            }
            if (Punto1.Longitude <= Punto2.Longitude)
            {
                Sentido = Sentido + "Oriente";
            }
            else
            {
                Sentido = Sentido + "Occidente";
            }
            return Sentido;
        }

        /// <summary>
        /// Insert the exception in the Database
        /// </summary>
        /// <param name="message">General error message</param>
        /// <param name="exception">real error exception </param>
        /// <param name="module">module where is failing</param>
        public void SetErrorLog(string message, string exception, string module)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
