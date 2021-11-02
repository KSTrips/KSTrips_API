using System;
using System.Collections.Generic;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Transversal.Response;
using KSTrips.Infrastructure.Interfaces;

namespace KSTrips.Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ReportQty> GetReportQtyByDates(DateTime dateFrom, DateTime dateTo,string email,int vehicleId)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetReportQtyByDates<ReportQty>(dateFrom,dateTo, userId,vehicleId);
        }

        public List<ReportCost> GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string email, int vehicleId)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetReportExpenseByDates<ReportCost>(dateFrom, dateTo, userId,vehicleId);
        }
        public List<ReportDetail> GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string email, int vehicleId)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetReportDetailByDates<ReportDetail>(dateFrom, dateTo, userId,vehicleId);
        }

        public List<ReportFinancial> GetReportFinancialByDates(DateTime dateFrom, DateTime dateTo, string email, int vehicleId)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetReportFinancialByDates<ReportFinancial>(dateFrom, dateTo, userId,vehicleId);
        }

        public ReportDashboard GetDashboardReport(DateTime dateFrom, DateTime dateTo, string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetDashboardReport(dateFrom, dateTo, userId);
             
        }

        public List<VehiclesMaintenance> GetMaintenanceVehicles(DateTime dateFrom, DateTime dateTo, string email)
        {
            var user = _unitOfWork.UserRepository.GetUserByEmail(email);
            var userId = user.Result[0].Id;
            return _unitOfWork.ReportRepository.GetMaintenanceVehicles<VehiclesMaintenance>(dateFrom, dateTo, userId);

        }
    }
}
