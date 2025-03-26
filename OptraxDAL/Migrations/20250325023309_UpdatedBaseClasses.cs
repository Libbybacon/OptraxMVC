using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedBaseClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductName",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Locations_OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Batches_BatchName",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductName",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Admin",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Admin",
                table: "IconCollections");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "BatchName",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Grow",
                table: "Strains",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Inventory",
                table: "Resources",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Admin",
                table: "Locations",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "ContainerTypeID",
                schema: "Admin",
                table: "ContainerTypes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "Admin",
                table: "Businesses",
                newName: "Details");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "Transfers",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Transfers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Inventory",
                table: "Transfers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "Transfers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Products",
                table: "PurchaseOrder",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Products",
                table: "Products",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Products",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "Plantings",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Plantings",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Grow",
                table: "Plantings",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Grow",
                table: "PlantEvents",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Icons",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Admin",
                table: "Icons",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "IconCollections",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "IconCollections",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Admin",
                table: "IconCollections",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                schema: "Products",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressID1",
                schema: "Admin",
                table: "Locations",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressID2",
                schema: "Admin",
                table: "Locations",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_Name",
                schema: "Grow",
                table: "Batches",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID1",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_BusinessID1",
                schema: "Admin",
                table: "Locations",
                column: "BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Businesses_BusinessID1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressID1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Batches_Name",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Products",
                table: "PurchaseOrder");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Grow",
                table: "PlantEvents");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Admin",
                table: "Icons");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Admin",
                table: "IconCollections");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Admin",
                table: "IconCollections");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Admin",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "Grow",
                table: "Strains",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "Inventory",
                table: "Resources",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "Admin",
                table: "Locations",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "ID",
                schema: "Admin",
                table: "ContainerTypes",
                newName: "ContainerTypeID");

            migrationBuilder.RenameColumn(
                name: "Details",
                schema: "Admin",
                table: "Businesses",
                newName: "Description");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Admin",
                table: "UoMs",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Admin",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                schema: "Products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                schema: "Products",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Products",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Inputs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Inputs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Admin",
                table: "Inputs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Inputs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Admin",
                table: "Icons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "IconCollections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Admin",
                table: "IconCollections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Admin",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Categories",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Inventory",
                table: "Categories",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "BatchName",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                schema: "Products",
                table: "Products",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations",
                column: "OffsiteLocation_AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                column: "OffsiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                column: "SiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_BatchName",
                schema: "Grow",
                table: "Batches",
                column: "BatchName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_OffsiteLocation_AddressID",
                schema: "Admin",
                table: "Locations",
                column: "OffsiteLocation_AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_OffsiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                column: "OffsiteLocation_BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Businesses_SiteLocation_BusinessID",
                schema: "Admin",
                table: "Locations",
                column: "SiteLocation_BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
