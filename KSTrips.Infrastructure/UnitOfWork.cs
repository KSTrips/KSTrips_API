using KSTrips.Infrastructure.Database;
using KSTrips.Infrastructure.Interfaces;
using KSTrips.Infrastructure.Services;



namespace KSTrips.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TripContext _context;

        public UnitOfWork(TripContext context)
        {
            _context = context;
            
        }

        public IExpenseRepository ExpenseRepository => new ExpenseRepository(_context);

        public IProviderRepository ProviderRepository => new ProviderRepository(_context);

        public ITaxRepository TaxRepository => new TaxRepository(_context);

        public ITollRespository TollRespository => new TollRepository(_context);

        public ITripRepository TripRepository => new TripRepository(_context);

        public ICarRepository CarRepository => new CarRepository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        public IReportRepository ReportRepository => new ReportRepository(_context);

        public IVehicleRepository VehicleRepository => new VehiceRepository(_context);

        public IRoleRepository RoleRepository => new RoleRepository(_context);
        public IUserRoleRepository UserRoleRepository => new UserRoleRepository(_context);
        public ISMTPRepository SMTPRepository => new SMTPRepository(_context);
        public ISubscriptionRepository SubscriptionRepository => new SubscriptionRepository(_context);

    }
}
