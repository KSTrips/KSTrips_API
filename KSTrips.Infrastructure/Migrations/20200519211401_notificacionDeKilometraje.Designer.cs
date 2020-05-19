﻿// <auto-generated />
using System;
using KSTrips.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KSTrips.Infrastructure.Migrations
{
    [DbContext(typeof(TripContext))]
    [Migration("20200519211401_notificacionDeKilometraje")]
    partial class notificacionDeKilometraje
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KSTrips.Domain.Entities.CarCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarTypes");

                    b.Property<decimal?>("CostAproxByDistance");

                    b.Property<decimal?>("CostAproxByWeigth");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.ToTable("CarCategories");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategory");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.HasKey("Id");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.SMTP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Email");

                    b.Property<string>("Host");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Password");

                    b.Property<int>("Port");

                    b.Property<string>("SMTPServer");

                    b.HasKey("Id");

                    b.ToTable("SMTPServer");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.SubscriptionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("QtyAllowedUsers");

                    b.HasKey("Id");

                    b.ToTable("SubscriptionTypes");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CostTax");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("TripDetailId");

                    b.HasKey("Id");

                    b.HasIndex("TripDetailId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Toll", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApproximateTime");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("DistanceKm");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("PageId");

                    b.Property<decimal?>("TotalCategory1");

                    b.Property<decimal?>("TotalCategory2");

                    b.Property<decimal?>("TotalCategory3");

                    b.Property<decimal?>("TotalCategory4");

                    b.Property<decimal?>("TotalCategory5");

                    b.Property<decimal?>("TotalCategory6");

                    b.Property<decimal?>("TotalCategory7");

                    b.Property<int>("TotalQtyTolls");

                    b.HasKey("Id");

                    b.ToTable("Tolls");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TollDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CostCategory1");

                    b.Property<decimal?>("CostCategory2");

                    b.Property<decimal?>("CostCategory3");

                    b.Property<decimal?>("CostCategory4");

                    b.Property<decimal?>("CostCategory5");

                    b.Property<decimal?>("CostCategory6");

                    b.Property<decimal?>("CostCategory7");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsActive");

                    b.Property<string>("NameToll");

                    b.Property<int>("TollId");

                    b.HasKey("Id");

                    b.HasIndex("TollId");

                    b.ToTable("TollDetails");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ApplyIca");

                    b.Property<bool>("ApplyReteFuente");

                    b.Property<bool>("ApplyTolls");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime?>("DateforPay");

                    b.Property<decimal>("Debt");

                    b.Property<string>("Destiny");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsUrban");

                    b.Property<string>("Origin");

                    b.Property<decimal>("Payment");

                    b.Property<int>("ProviderId");

                    b.Property<decimal?>("TotalProfit");

                    b.Property<decimal>("TotalTrip");

                    b.Property<int>("UserId");

                    b.Property<int?>("VehicleId");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("VehicleId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TripDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("ExpenseCategoryId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsToll");

                    b.Property<int>("TollId");

                    b.Property<decimal?>("TotalExpense");

                    b.Property<int>("TripId");

                    b.HasKey("Id");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthZeroId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateEndSubscription");

                    b.Property<DateTime?>("DateInitSubscription");

                    b.Property<DateTime?>("DateInitial");

                    b.Property<DateTime?>("DateModified");

                    b.Property<DateTime?>("DateUse");

                    b.Property<string>("Email");

                    b.Property<string>("FamilyName");

                    b.Property<string>("GivenName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("NotificationDays");

                    b.Property<string>("Provider");

                    b.Property<int?>("SubscriptionTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionTypeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<bool>("IsActive");

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarCategoryId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Driver");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LicensePlate");

                    b.Property<int>("NotificationKilometers");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CarCategoryId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Tax", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.TripDetail")
                        .WithMany("Taxes")
                        .HasForeignKey("TripDetailId");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TollDetail", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.Toll", "Toll")
                        .WithMany("TollDetails")
                        .HasForeignKey("TollId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Trip", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.Provider", "Provider")
                        .WithMany()
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KSTrips.Domain.Entities.User", "User")
                        .WithOne("Trip")
                        .HasForeignKey("KSTrips.Domain.Entities.Trip", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("KSTrips.Domain.Entities.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TripDetail", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.Trip", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.User", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.SubscriptionType", "SubscriptionType")
                        .WithMany()
                        .HasForeignKey("SubscriptionTypeId");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Vehicle", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.CarCategory", "CarCategory")
                        .WithMany()
                        .HasForeignKey("CarCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
