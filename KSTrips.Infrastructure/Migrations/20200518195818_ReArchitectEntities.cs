using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class ReArchitectEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Vehicles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TripId",
                table: "Trips",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TripDetailId",
                table: "TripDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TollId",
                table: "Tolls",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TollDetailId",
                table: "TollDetails",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "TaxId",
                table: "Taxes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SubscriptionTypeId",
                table: "SubscriptionTypes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ExpenseCategoryId",
                table: "ExpenseCategory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CarCategoryId",
                table: "CarCategories",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "UserRoles",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserRoles",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "SMTPServer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "SMTPServer",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "SMTPServer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "SMTPServer",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "SMTPServer");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "SMTPServer");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "SMTPServer");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "SMTPServer");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicles",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Trips",
                newName: "TripId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TripDetails",
                newName: "TripDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tolls",
                newName: "TollId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TollDetails",
                newName: "TollDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Taxes",
                newName: "TaxId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SubscriptionTypes",
                newName: "SubscriptionTypeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExpenseCategory",
                newName: "ExpenseCategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CarCategories",
                newName: "CarCategoryId");
        }
    }
}
