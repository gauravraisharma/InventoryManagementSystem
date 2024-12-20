using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class verifyTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "06ad3171-5df9-450e-82e2-72ddd0f47c1f");

            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "a08cebe1-e874-48a5-b534-22e24da86579");

            migrationBuilder.CreateTable(
                name: "VerificationCodes",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Expiry = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationCodes", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerificationCodes");

            migrationBuilder.InsertData(
                table: "AspNetRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "06ad3171-5df9-450e-82e2-72ddd0f47c1f", null, "user", "USER" },
                    { "a08cebe1-e874-48a5-b534-22e24da86579", null, "admin", "ADMIN" }
                });
        }
    }
}
