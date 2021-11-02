using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class modifiedUserscolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Given_Name",
                table: "Users",
                newName: "GivenName");

            migrationBuilder.RenameColumn(
                name: "Family_Name",
                table: "Users",
                newName: "FamilyName");

            migrationBuilder.RenameColumn(
                name: "AuthZero_Id",
                table: "Users",
                newName: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GivenName",
                table: "Users",
                newName: "Given_Name");

            migrationBuilder.RenameColumn(
                name: "FamilyName",
                table: "Users",
                newName: "Family_Name");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Users",
                newName: "AuthZero_Id");
        }
    }
}
