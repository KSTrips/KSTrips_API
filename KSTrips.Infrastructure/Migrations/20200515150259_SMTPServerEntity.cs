using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class SMTPServerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionType",
                table: "SubscriptionType");

            migrationBuilder.RenameTable(
                name: "SubscriptionType",
                newName: "SubscriptionTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionTypes",
                table: "SubscriptionTypes",
                column: "SubscriptionTypeId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "SMTPServer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SMTPServer = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Host = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SMTPServer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionTypes_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionTypes",
                principalColumn: "SubscriptionTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_SubscriptionTypes_SubscriptionTypeId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SMTPServer");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubscriptionTypes",
                table: "SubscriptionTypes");

            migrationBuilder.RenameTable(
                name: "SubscriptionTypes",
                newName: "SubscriptionType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubscriptionType",
                table: "SubscriptionType",
                column: "SubscriptionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SubscriptionType_SubscriptionTypeId",
                table: "Users",
                column: "SubscriptionTypeId",
                principalTable: "SubscriptionType",
                principalColumn: "SubscriptionTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
