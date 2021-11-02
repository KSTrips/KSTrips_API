using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class modifiedTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropColumn(
                name: "QtyTolls",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TotalToll",
                table: "TripDetails");

            migrationBuilder.RenameColumn(
                name: "ApplyTaxes",
                table: "Trips",
                newName: "ApplyReteFuente");

            migrationBuilder.AddColumn<bool>(
                name: "ApplyIca",
                table: "Trips",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TollId",
                table: "TripDetails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "expenseCategoryId",
                table: "TripDetails",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyIca",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "TollId",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "expenseCategoryId",
                table: "TripDetails");

            migrationBuilder.RenameColumn(
                name: "ApplyReteFuente",
                table: "Trips",
                newName: "ApplyTaxes");

            migrationBuilder.AddColumn<int>(
                name: "QtyTolls",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalToll",
                table: "TripDetails",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CostExpense = table.Column<decimal>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    TripDetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.ExpenseId);
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategory_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategory",
                        principalColumn: "ExpenseCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_TripDetails_TripDetailId",
                        column: x => x.TripDetailId,
                        principalTable: "TripDetails",
                        principalColumn: "TripDetailId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_ExpenseCategoryId",
                table: "Expenses",
                column: "ExpenseCategoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_TripDetailId",
                table: "Expenses",
                column: "TripDetailId");
        }
    }
}
