using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class ModifiedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateInitial",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateUse",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateInitial",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateUse",
                table: "Users");
        }
    }
}
