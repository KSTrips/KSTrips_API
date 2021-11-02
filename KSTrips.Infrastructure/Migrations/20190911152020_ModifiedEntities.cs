using Microsoft.EntityFrameworkCore.Migrations;

namespace KSTrips.Infrastructure.Migrations
{
    public partial class ModifiedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalTolls",
                table: "Tolls",
                newName: "TotalQtyTolls");

            migrationBuilder.RenameColumn(
                name: "NamePeaje",
                table: "TollDetails",
                newName: "NameToll");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Taxes",
                newName: "CostTax");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalToll",
                table: "TripDetails",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalExpense",
                table: "TripDetails",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "QtyTolls",
                table: "TripDetails",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<bool>(
                name: "IsToll",
                table: "TripDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TripDetailId",
                table: "Taxes",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostExpense",
                table: "Expenses",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Taxes_TripDetailId",
                table: "Taxes",
                column: "TripDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Taxes_TripDetails_TripDetailId",
                table: "Taxes",
                column: "TripDetailId",
                principalTable: "TripDetails",
                principalColumn: "TripDetailId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taxes_TripDetails_TripDetailId",
                table: "Taxes");

            migrationBuilder.DropIndex(
                name: "IX_Taxes_TripDetailId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "IsToll",
                table: "TripDetails");

            migrationBuilder.DropColumn(
                name: "TripDetailId",
                table: "Taxes");

            migrationBuilder.DropColumn(
                name: "CostExpense",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "TotalQtyTolls",
                table: "Tolls",
                newName: "TotalTolls");

            migrationBuilder.RenameColumn(
                name: "NameToll",
                table: "TollDetails",
                newName: "NamePeaje");

            migrationBuilder.RenameColumn(
                name: "CostTax",
                table: "Taxes",
                newName: "Value");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalToll",
                table: "TripDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalExpense",
                table: "TripDetails",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "QtyTolls",
                table: "TripDetails",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
