using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class addNoticationDaysUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationDays",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationDays",
                table: "Users");
        }
    }
}
