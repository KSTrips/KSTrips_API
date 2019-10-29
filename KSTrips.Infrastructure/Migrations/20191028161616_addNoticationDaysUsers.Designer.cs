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
    [Migration("20191028161616_addNoticationDaysUsers")]
    partial class addNoticationDaysUsers
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
                    b.Property<int>("CarCategoryId")
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

                    b.HasKey("CarCategoryId");

                    b.ToTable("CarCategories");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.ExpenseCategory", b =>
                {
                    b.Property<int>("ExpenseCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.HasKey("ExpenseCategoryId");

                    b.ToTable("ExpenseCategory");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Provider", b =>
                {
                    b.Property<int>("ProviderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.HasKey("ProviderId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Tax", b =>
                {
                    b.Property<int>("TaxId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CostTax");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("TripDetailId");

                    b.HasKey("TaxId");

                    b.HasIndex("TripDetailId");

                    b.ToTable("Taxes");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Toll", b =>
                {
                    b.Property<int>("TollId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApproximateTime");

                    b.Property<int>("DistanceKm");

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

                    b.HasKey("TollId");

                    b.ToTable("Tolls");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TollDetail", b =>
                {
                    b.Property<int>("TollDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("CostCategory1");

                    b.Property<decimal?>("CostCategory2");

                    b.Property<decimal?>("CostCategory3");

                    b.Property<decimal?>("CostCategory4");

                    b.Property<decimal?>("CostCategory5");

                    b.Property<decimal?>("CostCategory6");

                    b.Property<decimal?>("CostCategory7");

                    b.Property<string>("NameToll");

                    b.Property<int>("TollId");

                    b.HasKey("TollDetailId");

                    b.HasIndex("TollId");

                    b.ToTable("TollDetails");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("TripId")
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

                    b.Property<string>("Origin");

                    b.Property<decimal>("Payment");

                    b.Property<int>("ProviderId");

                    b.Property<decimal?>("TotalProfit");

                    b.Property<decimal>("TotalTrip");

                    b.Property<int>("UserId");

                    b.HasKey("TripId");

                    b.HasIndex("ProviderId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TripDetail", b =>
                {
                    b.Property<int>("TripDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<int>("ExpenseCategoryId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsToll");

                    b.Property<int>("TollId");

                    b.Property<decimal?>("TotalExpense");

                    b.Property<int>("TripId");

                    b.HasKey("TripDetailId");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AuthZeroId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

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

                    b.HasKey("UserId");

                    b.ToTable("Users");
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
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TripDetail", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.Trip", "Trip")
                        .WithMany("TripDetails")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
