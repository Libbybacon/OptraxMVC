using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class InventoryCategoryModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCategories_InventoryCategories_ParentCategoryID",
                table: "InventoryCategories");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCategories_ParentCategoryID",
                table: "InventoryCategories");

            migrationBuilder.DropColumn(
                name: "ParentCategoryID",
                table: "InventoryCategories");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_ParentID",
                table: "InventoryCategories",
                column: "ParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCategories_InventoryCategories_ParentID",
                table: "InventoryCategories",
                column: "ParentID",
                principalTable: "InventoryCategories",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryCategories_InventoryCategories_ParentID",
                table: "InventoryCategories");

            migrationBuilder.DropIndex(
                name: "IX_InventoryCategories_ParentID",
                table: "InventoryCategories");

            migrationBuilder.AddColumn<int>(
                name: "ParentCategoryID",
                table: "InventoryCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_ParentCategoryID",
                table: "InventoryCategories",
                column: "ParentCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryCategories_InventoryCategories_ParentCategoryID",
                table: "InventoryCategories",
                column: "ParentCategoryID",
                principalTable: "InventoryCategories",
                principalColumn: "ID");
        }
    }
}
