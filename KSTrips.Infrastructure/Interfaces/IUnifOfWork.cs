namespace KSTrips.Infrastructure.Interfaces
{
    public interface IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; }
        IProviderRepository ProviderRepository { get; }
        ITaxRepository TaxRepository { get; }
        ITollRespository TollRespository { get; }
        ITripRepository TripRepository { get; }
        ICarRepository CarRepository { get; }
        IUserRepository UserRepository { get; }
        IReportRepository ReportRepository { get; }
        IVehicleRepository VehicleRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }
        ISMTPRepository SMTPRepository { get; }
        ISubscriptionRepository SubscriptionRepository { get; }

    }
}
