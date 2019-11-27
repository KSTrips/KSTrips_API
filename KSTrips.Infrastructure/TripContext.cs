using KSTrips.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KSTrips.Infrastructure
{

    public class TripContext : DbContext
    {
        private IConfiguration Configuration { get; }
        private string ConnectionString => this.Configuration.GetConnectionString("TripContext");

        //Constructor con parametros para la configuracion
        public TripContext(DbContextOptions options, IConfiguration configuration): base(options)
        {
            Configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(this.ConnectionString);
            }
        }

        public DbSet<Provider> Providers { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Toll> Tolls { get; set; }
        public DbSet<TollDetail> TollDetails { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripDetail> TripDetails { get; set; }
        public DbSet<CarCategory> CarCategories { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategory { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripDetail>()
                .HasMany(cbs => cbs.Taxes);

            modelBuilder.Entity<Trip>()
                .HasMany(cbs => cbs.TripDetails);

            modelBuilder.Entity<Trip>()
                .HasOne(cbs => cbs.Provider);

        }

    }
}
