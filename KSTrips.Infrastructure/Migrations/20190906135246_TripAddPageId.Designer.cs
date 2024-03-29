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
    [Migration("20190906135246_TripAddPageId")]
    partial class TripAddPageId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KSTrips.Domain.Entities.Expense", b =>
                {
                    b.Property<int>("ExpenseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<int>("TripDetailId");

                    b.HasKey("ExpenseId");

                    b.HasIndex("TripDetailId");

                    b.ToTable("Expenses");
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

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<string>("Description");

                    b.Property<bool>("IsActive");

                    b.Property<decimal>("Value");

                    b.HasKey("TaxId");

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

                    b.Property<decimal?>("TotalCategory1");

                    b.Property<decimal?>("TotalCategory2");

                    b.Property<decimal?>("TotalCategory3");

                    b.Property<decimal?>("TotalCategory4");

                    b.Property<decimal?>("TotalCategory5");

                    b.Property<decimal?>("TotalCategory6");

                    b.Property<decimal?>("TotalCategory7");

                    b.Property<int>("TotalTolls");

                    b.HasKey("TollId");

                    b.ToTable("Tolls");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.TollDetail", b =>
                {
                    b.Property<int>("TollDetailId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamePeaje");

                    b.Property<decimal>("TollCost");

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

                    b.Property<bool>("ApplyTaxes");

                    b.Property<bool>("ApplyTolls");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateModified");

                    b.Property<decimal>("Debt");

                    b.Property<string>("Destiny");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Origin");

                    b.Property<int>("PageId");

                    b.Property<decimal>("Payment");

                    b.Property<int?>("ProviderId");

                    b.Property<decimal?>("TotalProfit");

                    b.Property<decimal>("TotalTrip");

                    b.HasKey("TripId");

                    b.HasIndex("ProviderId");

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

                    b.Property<bool>("IsActive");

                    b.Property<int>("QtyTolls");

                    b.Property<decimal>("TotalExpense");

                    b.Property<decimal>("TotalToll");

                    b.Property<int>("TripId");

                    b.HasKey("TripDetailId");

                    b.HasIndex("TripId");

                    b.ToTable("TripDetails");
                });

            modelBuilder.Entity("KSTrips.Domain.Entities.Expense", b =>
                {
                    b.HasOne("KSTrips.Domain.Entities.TripDetail", "TripDetail")
                        .WithMany("Expenses")
                        .HasForeignKey("TripDetailId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                        .HasForeignKey("ProviderId");
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
