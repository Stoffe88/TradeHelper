using Microsoft.EntityFrameworkCore.Migrations;

namespace TradeHelper.Migrations
{
    public partial class TwoEditColumnsInsteadOfOneInStocksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEdited",
                table: "Stock");

            migrationBuilder.AddColumn<bool>(
                name: "NameIsEdited",
                table: "Stock",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ValueIsEdited",
                table: "Stock",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameIsEdited",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "ValueIsEdited",
                table: "Stock");

            migrationBuilder.AddColumn<bool>(
                name: "IsEdited",
                table: "Stock",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
