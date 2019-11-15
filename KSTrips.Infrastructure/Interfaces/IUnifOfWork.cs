namespace KSTrips.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; }

        IProviderRepository ProviderRepository { get; }

        ITaxRepository TaxRepository { get; }

        ITollRespository TollRespository { get; }

        ITripRepository TripRepository { get; }

        ICarCategoryRepository CarCategoryRepository { get; }

        IUserRepository UserRepository { get; }
        IReportRepository ReportRepository { get; }
    
}
}
