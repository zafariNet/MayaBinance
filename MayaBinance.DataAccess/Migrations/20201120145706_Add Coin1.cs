using Microsoft.EntityFrameworkCore.Migrations;

namespace MayaBinance.DataAccess.Migrations
{
    public partial class AddCoin1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Trade");

            migrationBuilder.RenameTable(
                name: "Coins",
                newName: "Coins",
                newSchema: "Trade");

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                schema: "Trade",
                table: "Coins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "Trade",
                table: "Coins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Trade",
                table: "Coins",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Symbol",
                schema: "Trade",
                table: "Coins",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                schema: "Trade",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "Trade",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Trade",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Symbol",
                schema: "Trade",
                table: "Coins");

            migrationBuilder.RenameTable(
                name: "Coins",
                schema: "Trade",
                newName: "Coins");
        }
    }
}
