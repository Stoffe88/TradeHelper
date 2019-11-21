using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeHelper.Migrations
{
    public partial class AddEditColumnToStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValueDate",
                table: "Stock");

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "Stock",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "Stock");

            migrationBuilder.AddColumn<DateTime>(
                name: "ValueDate",
                table: "Stock",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
