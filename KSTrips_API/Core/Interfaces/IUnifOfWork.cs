using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace KSTrips_API.Core.Interfaces
{
    public interface IUnitfOfWork
    {
        IExpenseRepository ExpenseRepository { get; }

        IProviderRepository ProviderRepository { get; }

        ITaxRepository TaxRepository { get; }

        ITollRespository TollRespository { get; }

        ITripRepository TripRepository { get; }

        ICarCategoryRepository CarCategoryRepository { get; }
    }
}
