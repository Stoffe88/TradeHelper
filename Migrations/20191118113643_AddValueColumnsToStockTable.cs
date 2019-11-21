using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeHelper.Migrations
{
    public partial class AddValueColumnsToStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Stock",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ValueDate",
                table: "Stock",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ValueDate",
                table: "Stock");
        }
    }
}
