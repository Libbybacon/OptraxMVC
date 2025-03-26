using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class MapObjChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Inventory",
                table: "Lights");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Varieties",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "UoMs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "StockItems",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "SalesOrders",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Products",
                table: "ProductItems",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Products",
                table: "ProductBatches",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<int>(
                name: "IconID",
                schema: "Admin",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "Inputs",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Cultivars",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Crops",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "Businesses",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "Address",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations",
                column: "IconID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "IconID",
                schema: "Admin",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "Lights",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Icons_IconID",
                schema: "Admin",
                table: "Locations",
                column: "IconID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
