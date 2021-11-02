using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class AddCategoryCostByToll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TollCost",
                table: "TollDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory1",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory2",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory3",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory4",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory5",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory6",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostCategory7",
                table: "TollDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostCategory1",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory2",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory3",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory4",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory5",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory6",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "CostCategory7",
                table: "TollDetails");

            migrationBuilder.AddColumn<decimal>(
                name: "TollCost",
                table: "TollDetails",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
