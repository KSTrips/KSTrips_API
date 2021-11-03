using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class addSMTPServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionTypeId",
                table: "Users",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "SubscriptionTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "SubscriptionTypeId",
                table: "Users",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "SubscriptionTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
