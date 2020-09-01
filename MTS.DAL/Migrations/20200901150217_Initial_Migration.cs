using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MTS.DAL.Migrations
{
    public partial class Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Medicine",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 42, nullable: false),
                    Brand = table.Column<string>(maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(16, 2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "date", nullable: false),
                    Notes = table.Column<string>(maxLength: 4000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Medicine",
                columns: new[] { "Id", "Brand", "ExpiryDate", "Notes", "Price", "Quantity" },
                values: new object[] { "09012020-132323186-4d14c653-461f-426f-ae39", "Abc", new DateTime(2020, 9, 11, 0, 0, 0, 0, DateTimeKind.Local), "This medicine is for fever", 12.1m, 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine",
                schema: "dbo");
        }
    }
}
