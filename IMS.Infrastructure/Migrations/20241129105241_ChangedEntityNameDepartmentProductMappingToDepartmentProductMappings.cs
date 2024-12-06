using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntityNameDepartmentProductMappingToDepartmentProductMappings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProductMapping_Departments_DepartmentId",
                table: "DepartmentProductMapping");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProductMapping_Products_ProductId",
                table: "DepartmentProductMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentProductMapping",
                table: "DepartmentProductMapping");

            migrationBuilder.RenameTable(
                name: "DepartmentProductMapping",
                newName: "DepartmentProductMappings");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentProductMapping_ProductId",
                table: "DepartmentProductMappings",
                newName: "IX_DepartmentProductMappings_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentProductMappings",
                table: "DepartmentProductMappings",
                columns: new[] { "DepartmentId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProductMappings_Departments_DepartmentId",
                table: "DepartmentProductMappings",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProductMappings_Products_ProductId",
                table: "DepartmentProductMappings",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProductMappings_Departments_DepartmentId",
                table: "DepartmentProductMappings");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentProductMappings_Products_ProductId",
                table: "DepartmentProductMappings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmentProductMappings",
                table: "DepartmentProductMappings");

            migrationBuilder.RenameTable(
                name: "DepartmentProductMappings",
                newName: "DepartmentProductMapping");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentProductMappings_ProductId",
                table: "DepartmentProductMapping",
                newName: "IX_DepartmentProductMapping_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmentProductMapping",
                table: "DepartmentProductMapping",
                columns: new[] { "DepartmentId", "ProductId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProductMapping_Departments_DepartmentId",
                table: "DepartmentProductMapping",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentProductMapping_Products_ProductId",
                table: "DepartmentProductMapping",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
