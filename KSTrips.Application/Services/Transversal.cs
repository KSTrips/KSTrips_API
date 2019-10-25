using System.Collections.Generic;
using System.Linq;
using KSTrips.Domain.Entities;
using KSTrips.Domain.Transversal;

namespace KSTrips.Application.Services
{
    public class Transversal {

        /// <summary>
        /// Metodo que calcula el abono del flete
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculatePayment(decimal totalPay)
        {
            var payment = totalPay * 70 / 100;
            return payment;
        }

        /// <summary>
        /// Metodo que calcula el restante del flete
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateDebt(decimal totalPay)
        {
            var ica = CalculateIca(totalPay);
            var retefuente = CalculateRetefuente(totalPay);
            var payment = CalculatePayment(totalPay);
            var debt = totalPay - payment - ica - retefuente;
            return debt;
        }

        /// <summary>
        /// metodo que calcula el descuento de ica por 0.008%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateIca(decimal totalPay)
        {
            var discountIca = totalPay * 8 / 1000;
            return discountIca;
        }

        /// <summary>
        /// Metodo que calcula el descuento de retefuente 1%
        /// </summary>
        /// <param name="totalPay"></param>
        /// <returns></returns>
        public decimal CalculateRetefuente(decimal totalPay)
        {
            var discountRetefuente = totalPay * 1 / 100;
            return discountRetefuente;
        }


        public decimal CalculateExpenses(List<Expense> expenses)
        {
            decimal sumexpenses = expenses.Sum(ls => ls.CostExpense);
            return sumexpenses;
        }

        public decimal CalculateTolls(int categoria, Toll tolls)
        {

            decimal sumTolls = 0;

            if (tolls == null)
                return sumTolls;

            switch (categoria)
            {
                case 1:
                    if (tolls.TotalCategory1 != null) sumTolls = (decimal)tolls.TotalCategory1;
                    break;
                case 2:
                    if (tolls.TotalCategory2 != null) sumTolls = (decimal)tolls.TotalCategory2;
                    break;
                case 3:
                    if (tolls.TotalCategory3 != null) sumTolls = (decimal)tolls.TotalCategory3;
                    break;
                case 4:
                    if (tolls.TotalCategory4 != null) sumTolls = (decimal)tolls.TotalCategory4;
                    break;
                case 5:
                    if (tolls.TotalCategory5 != null) sumTolls = (decimal)tolls.TotalCategory5;
                    break;
                case 6:
                    if (tolls.TotalCategory6 != null) sumTolls = (decimal)tolls.TotalCategory6;
                    break;
                case 7:
                    if (tolls.TotalCategory7 != null) sumTolls = (decimal)tolls.TotalCategory7;
                    break;
                default:
                    break;

            }

            return sumTolls;
        }

        public decimal CalculateProfit(SimulatorEntity dataSimulator, Toll _tolls, List<Expense> _expenses)
        {
            var ica = CalculateIca(dataSimulator.TotalPay);
            var retefuente = CalculateRetefuente(dataSimulator.TotalPay);
            var tolls = CalculateTolls(dataSimulator.CarCategory, _tolls);
            var expenses = CalculateExpenses(_expenses);

            var profit = dataSimulator.TotalPay - ica - retefuente - tolls - expenses;
            return profit;
        }
    }
}
