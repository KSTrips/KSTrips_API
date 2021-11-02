using System.Collections.Generic;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;

namespace KSTrips.Infrastructure.Interfaces
{
    public interface IProviderRepository
    {
        Task<List<Provider>> GetAllProviders();
        Task<List<Provider>> GetProviderById(int providerId);
        Task<List<Provider>> GetProviderByName(string providerName);
        bool SaveProvider(Provider provider);
        bool UpdateProvider(Provider provider);
    }
}
