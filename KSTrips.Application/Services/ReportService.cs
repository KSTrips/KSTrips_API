using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Application.Interfaces;
using KSTrips.Domain.Entities;
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

        public List<ReportQty> GetReportQtyByDates(DateTime dateFrom, DateTime dateTo,string authZeroId)
        {
            var user = _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
            var userId = user.Result[0].UserId;
            return _unitOfWork.ReportRepository.GetReportQtyByDates<ReportQty>(dateFrom,dateTo, userId);
        }

        public List<ReportCost> GetReportExpenseByDates(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            var user = _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
            var userId = user.Result[0].UserId;
            return _unitOfWork.ReportRepository.GetReportExpenseByDates<ReportCost>(dateFrom, dateTo, userId);
        }
        public List<ReportDetail> GetReportDetailByDates(DateTime dateFrom, DateTime dateTo, string authZeroId)
        {
            var user = _unitOfWork.UserRepository.GetUserByAuthZeroId(authZeroId);
            var userId = user.Result[0].UserId;
            return _unitOfWork.ReportRepository.GetReportDetailByDates<ReportDetail>(dateFrom, dateTo, userId);
        }
    }
}
