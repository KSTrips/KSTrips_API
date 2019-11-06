
using KSTrips.Infrastructure;
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

        public ICarCategoryRepository CarCategoryRepository => new CarCategoryRespository(_context);

        public IUserRepository UserRepository => new UserRepository(_context);

        public IReportRepository ReportRepository => new ReportRepository(_context);


    }
}
