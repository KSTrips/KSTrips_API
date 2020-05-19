using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class newEntitiesForNewFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubscriptionTypeId",
                table: "Users",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tolls",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Tolls",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Tolls",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tolls",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "TollDetails",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "TollDetails",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TollDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubscriptionType",
                columns: table => new
                {
                    SubscriptionTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    QtyAllowedUsers = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionType", x => x.SubscriptionTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "SubscriptionTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SubscriptionType");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubscriptionTypeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tolls");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Tolls");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Tolls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tolls");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "TollDetails");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TollDetails");
        }
    }
}
