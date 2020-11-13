using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MayaBinance.DataAccess.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "identity");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EmailOrUserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(350)", maxLength: 350, nullable: true),
                    Address_City = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_Country = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Address_ZipCode = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    RowVersion = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoftDelete = table.Column<bool>(type: "bit", nullable: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeleterId",
                        column: x => x.DeleterId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifierId",
                        column: x => x.ModifierId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatorId",
                schema: "identity",
                table: "Users",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeleterId",
                schema: "identity",
                table: "Users",
                column: "DeleterId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifierId",
                schema: "identity",
                table: "Users",
                column: "ModifierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "identity");
        }
    }
}
