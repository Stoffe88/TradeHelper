using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeHelper.Migrations
{
    public partial class AddProfitColumnToStockTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Profit",
                table: "Stock",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Profit",
                table: "Stock");
        }
    }
}
