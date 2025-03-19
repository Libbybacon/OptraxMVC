using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddProductSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DurableItems_StockItems_ID",
                schema: "Inventory",
                table: "DurableItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DurableItems",
                schema: "Inventory",
                table: "DurableItems");

            migrationBuilder.EnsureSchema(
                name: "Products");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderStockItem",
                schema: "Inventory",
                newName: "PurchaseOrderStockItem");

            migrationBuilder.RenameTable(
                name: "PurchaseOrder",
                schema: "Inventory",
                newName: "PurchaseOrder",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "ProductItems",
                newName: "ProductItems",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "ProductBatches",
                newName: "ProductBatches",
                newSchema: "Products");

            migrationBuilder.RenameTable(
                name: "Locations",
                newName: "Locations",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "DurableItems",
                schema: "Inventory",
                newName: "Durables",
                newSchema: "Inventory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Durables",
                schema: "Inventory",
                table: "Durables",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Durables_StockItems_ID",
                schema: "Inventory",
                table: "Durables",
                column: "ID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Durables_StockItems_ID",
                schema: "Inventory",
                table: "Durables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Durables",
                schema: "Inventory",
                table: "Durables");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderStockItem",
                newName: "PurchaseOrderStockItem",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "PurchaseOrder",
                schema: "Products",
                newName: "PurchaseOrder",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "ProductItems",
                schema: "Products",
                newName: "ProductItems");

            migrationBuilder.RenameTable(
                name: "ProductBatches",
                schema: "Products",
                newName: "ProductBatches");

            migrationBuilder.RenameTable(
                name: "Locations",
                schema: "Admin",
                newName: "Locations");

            migrationBuilder.RenameTable(
                name: "Durables",
                schema: "Inventory",
                newName: "DurableItems",
                newSchema: "Inventory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DurableItems",
                schema: "Inventory",
                table: "DurableItems",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_DurableItems_StockItems_ID",
                schema: "Inventory",
                table: "DurableItems",
                column: "ID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
