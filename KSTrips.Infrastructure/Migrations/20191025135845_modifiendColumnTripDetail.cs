using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class modifiendColumnTripDetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "expenseCategoryId",
                table: "TripDetails",
                newName: "ExpenseCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExpenseCategoryId",
                table: "TripDetails",
                newName: "expenseCategoryId");
        }
    }
}
