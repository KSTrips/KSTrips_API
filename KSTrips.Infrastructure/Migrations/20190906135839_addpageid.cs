using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class addpageid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Tolls",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageId",
                table: "Tolls");

            migrationBuilder.AddColumn<int>(
                name: "PageId",
                table: "Trips",
                nullable: false,
                defaultValue: 0);
        }
    }
}
