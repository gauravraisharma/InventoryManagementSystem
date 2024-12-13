using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "50b502cf-9652-44f2-bc64-933785657981");

            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "c232778c-f9ef-47b1-b838-53901dc3c923");

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    ProductSizeId = table.Column<string>(type: "nvarchar(36)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_ProductSizes_ProductSizeId",
                        column: x => x.ProductSizeId,
                        principalTable: "ProductSizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4c69406-a22e-43b6-a2d6-e3e1168e90bd", null, "admin", "ADMIN" },
                    { "bc3c91c1-74aa-4288-86f7-707b23f85b75", null, "user", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductSizeId",
                table: "Carts",
                column: "ProductSizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId_ProductId_ProductSizeId",
                table: "Carts",
                columns: new[] { "UserId", "ProductId", "ProductSizeId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "b4c69406-a22e-43b6-a2d6-e3e1168e90bd");

            migrationBuilder.DeleteData(
                table: "AspNetRole",
                keyColumn: "Id",
                keyValue: "bc3c91c1-74aa-4288-86f7-707b23f85b75");

            migrationBuilder.InsertData(
                table: "AspNetRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "50b502cf-9652-44f2-bc64-933785657981", null, "admin", "ADMIN" },
                    { "c232778c-f9ef-47b1-b838-53901dc3c923", null, "user", "USER" }
                });
        }
    }
}
