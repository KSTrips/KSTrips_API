﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class RemoveCategoryFromTrips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_CarCategories_CarCategoryId",
                table: "Trips");

            migrationBuilder.DropIndex(
                name: "IX_Trips_CarCategoryId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "CarCategoryId",
                table: "Trips");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarCategoryId",
                table: "Trips",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Trips_CarCategoryId",
                table: "Trips",
                column: "CarCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_CarCategories_CarCategoryId",
                table: "Trips",
                column: "CarCategoryId",
                principalTable: "CarCategories",
                principalColumn: "CarCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
