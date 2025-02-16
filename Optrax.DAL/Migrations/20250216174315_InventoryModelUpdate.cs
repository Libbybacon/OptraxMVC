using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class InventoryModelUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubCategoryID",
                table: "InventoryItems");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryID",
                table: "InventoryItems",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_InventoryCategories_CategoryID",
                table: "InventoryItems",
                column: "CategoryID",
                principalTable: "InventoryCategories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_InventoryCategories_CategoryID",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_CategoryID",
                table: "InventoryItems");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryID",
                table: "InventoryItems",
                type: "int",
                nullable: true);
        }
    }
}
