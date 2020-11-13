using Microsoft.EntityFrameworkCore.Migrations;

namespace MayaBinance.DataAccess.Migrations
{
    public partial class Addpasswordtouserconfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "identity",
                table: "Users",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "identity",
                table: "Users");
        }
    }
}
