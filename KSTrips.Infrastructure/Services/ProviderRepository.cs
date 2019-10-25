using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KSTrips.Infrastructure.Services
{
    public class ProviderRepository : IProviderRepository
    {
        private TripContext Context { get; }

        public ProviderRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<Provider>> GetAllProviders()
        {
            return await Context.Providers.ToListAsync( );
        }


        public bool SaveProvider(Provider provider)
        {
            try
            {
                var existprovider = Context.Providers.Where(ls => ls.Description == provider.Description.Trim().ToLower()).ToListAsync();

                if (existprovider.Result.Count == 0)
                {
                    provider.DateCreated = DateTime.Now;
                    provider.CreatedBy = "Administrator";
                    provider.IsActive = true;
                    Context.Providers.Add(provider);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateProvider(Provider provider)
        {
            try
            {

                Context.Entry(provider).State = EntityState.Modified;
                provider.DateModified = DateTime.Now;

                    Context.Entry(provider).Property(p => p.DateModified).IsModified = true;
                    Context.Entry(provider).Property(p => p.IsActive).IsModified = true;
                    Context.Entry(provider).Property(p => p.Description).IsModified = true;

                    Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }
    }
}
