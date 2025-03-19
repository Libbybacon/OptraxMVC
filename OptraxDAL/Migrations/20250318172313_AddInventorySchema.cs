using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddInventorySchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Businesses_BusinessID",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Crops_CropID",
                table: "Batches");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Strains_StrainID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivars_Species_SpeciesID",
                table: "Cultivars");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_UserID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_Locations_DestinationID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_Locations_OriginID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_StockItems_StockItemID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_AddressID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Addresses_OffsiteLocation_AddressID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Crops_CropID",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Crops_CropID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_InventoryItems_InventoryItemID",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_InventoryTransfers_TransferID",
                table: "TransferApprovals");

            migrationBuilder.DropTable(
                name: "IconCollectionMapIcon",
                schema: "Map");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "InventoryCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Varieties",
                table: "Varieties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryTransfers",
                table: "InventoryTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivars",
                table: "Cultivars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crops",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_BatchID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_Name",
                table: "Crops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batches",
                table: "Batches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BatchID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CurrentPhase",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "ExpectedFlowerDays",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "WasteQuantity",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "WasteQuantityUoM",
                table: "Crops");

            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.EnsureSchema(
                name: "Grow");

            migrationBuilder.EnsureSchema(
                name: "Inventory");

            migrationBuilder.RenameTable(
                name: "UoMs",
                newName: "UoMs",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "TransferApprovals",
                newName: "TransferApprovals",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Strains",
                newName: "Strains",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "StockItems",
                newName: "StockItems",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Species",
                newName: "Species",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Plants",
                newName: "Plants",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "PlantEvents",
                newName: "PlantEvents",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Lights",
                newName: "Lights",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Inputs",
                newName: "Inputs",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "Icons",
                schema: "Map",
                newName: "Icons",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "IconCollections",
                schema: "Map",
                newName: "IconCollections",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "DurableItems",
                newName: "DurableItems",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "ContainerTypes",
                newName: "ContainerTypes",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "Consumables",
                newName: "Consumables",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Businesses",
                newName: "Businesses",
                newSchema: "Admin");

            migrationBuilder.RenameTable(
                name: "Varieties",
                newName: "Variety",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "InventoryTransfers",
                newName: "Transfers",
                newSchema: "Inventory");

            migrationBuilder.RenameTable(
                name: "Cultivars",
                newName: "Cultivar",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Crops",
                newName: "Crop",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Batches",
                newName: "Batch",
                newSchema: "Grow");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address",
                newSchema: "Admin");

            migrationBuilder.RenameColumn(
                name: "CropID",
                table: "ProductItems",
                newName: "SalesOrderID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_CropID",
                table: "ProductItems",
                newName: "IX_ProductItems_SalesOrderID");

            migrationBuilder.RenameColumn(
                name: "InventoryItemID",
                schema: "Inventory",
                table: "StockItems",
                newName: "ResourceID");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_InventoryItemID",
                schema: "Inventory",
                table: "StockItems",
                newName: "IX_StockItems_ResourceID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTransfers_UserID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTransfers_StockItemID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_StockItemID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTransfers_OriginID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_OriginID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryTransfers_DestinationID",
                schema: "Inventory",
                table: "Transfers",
                newName: "IX_Transfers_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivars_SpeciesID",
                schema: "Grow",
                table: "Cultivar",
                newName: "IX_Cultivar_SpeciesID");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                schema: "Grow",
                table: "Crop",
                newName: "VarietyID");

            migrationBuilder.RenameColumn(
                name: "ExpectedVegDays",
                schema: "Grow",
                table: "Crop",
                newName: "CultivarID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_StrainID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_StrainID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_SpeciesID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_RowLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_RowLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_RoomLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_RoomLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_GreenhouseLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crop",
                newName: "IX_Crop_FieldLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Batches_CropID",
                schema: "Grow",
                table: "Batch",
                newName: "IX_Batch_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_BusinessID",
                schema: "Admin",
                table: "Address",
                newName: "IX_Address_BusinessID");

            migrationBuilder.AddColumn<int>(
                name: "PlantingID",
                table: "ProductItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IconID",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StrainID",
                schema: "Grow",
                table: "Crop",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesID",
                schema: "Grow",
                table: "Crop",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "Crop",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderID",
                schema: "Grow",
                table: "Batch",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variety",
                schema: "Grow",
                table: "Variety",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transfers",
                schema: "Inventory",
                table: "Transfers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivar",
                schema: "Grow",
                table: "Cultivar",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crop",
                schema: "Grow",
                table: "Crop",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batch",
                schema: "Grow",
                table: "Batch",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                schema: "Admin",
                table: "Address",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Categories",
                schema: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HexColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TextColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "Inventory",
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "IconIconCollection",
                schema: "Admin",
                columns: table => new
                {
                    CollectionsID = table.Column<int>(type: "int", nullable: false),
                    IconsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconIconCollection", x => new { x.CollectionsID, x.IconsID });
                    table.ForeignKey(
                        name: "FK_IconIconCollection_IconCollections_CollectionsID",
                        column: x => x.CollectionsID,
                        principalSchema: "Admin",
                        principalTable: "IconCollections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IconIconCollection_Icons_IconsID",
                        column: x => x.IconsID,
                        principalSchema: "Admin",
                        principalTable: "Icons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planting",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropID = table.Column<int>(type: "int", nullable: false),
                    BatchID = table.Column<int>(type: "int", maxLength: 50, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    CurrentStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WasteQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    WasteQuantityUoM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planting", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Planting_Batch_BatchID",
                        column: x => x.BatchID,
                        principalSchema: "Grow",
                        principalTable: "Batch",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Planting_Crop_CropID",
                        column: x => x.CropID,
                        principalSchema: "Grow",
                        principalTable: "Crop",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Planting_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                schema: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    FulfillmentDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ShipDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VerifiedReceivedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                schema: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "Inventory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    StockType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultUoM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    StockUoM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: true),
                    NeedsTransferApproval = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Resources_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalSchema: "Inventory",
                        principalTable: "Categories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderStockItem",
                schema: "Inventory",
                columns: table => new
                {
                    ItemsID = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrdersID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderStockItem", x => new { x.ItemsID, x.PurchaseOrdersID });
                    table.ForeignKey(
                        name: "FK_PurchaseOrderStockItem_PurchaseOrder_PurchaseOrdersID",
                        column: x => x.PurchaseOrdersID,
                        principalSchema: "Inventory",
                        principalTable: "PurchaseOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderStockItem_StockItems_ItemsID",
                        column: x => x.ItemsID,
                        principalSchema: "Inventory",
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_PlantingID",
                table: "ProductItems",
                column: "PlantingID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_IconID",
                table: "Locations",
                column: "IconID");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_CultivarID",
                schema: "Grow",
                table: "Crop",
                column: "CultivarID");

            migrationBuilder.CreateIndex(
                name: "IX_Crop_Name",
                schema: "Grow",
                table: "Crop",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crop_VarietyID",
                schema: "Grow",
                table: "Crop",
                column: "VarietyID");

            migrationBuilder.CreateIndex(
                name: "IX_Batch_BatchName",
                schema: "Grow",
                table: "Batch",
                column: "BatchName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                schema: "Inventory",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentID",
                schema: "Inventory",
                table: "Categories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_IconIconCollection_IconsID",
                schema: "Admin",
                table: "IconIconCollection",
                column: "IconsID");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_BatchID",
                schema: "Grow",
                table: "Planting",
                column: "BatchID");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_CropID",
                schema: "Grow",
                table: "Planting",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Planting_LocationID",
                schema: "Grow",
                table: "Planting",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderStockItem_PurchaseOrdersID",
                schema: "Inventory",
                table: "PurchaseOrderStockItem",
                column: "PurchaseOrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_CategoryID",
                schema: "Inventory",
                table: "Resources",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_Name",
                schema: "Inventory",
                table: "Resources",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_SKU",
                schema: "Inventory",
                table: "Resources",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Businesses_BusinessID",
                schema: "Admin",
                table: "Address",
                column: "BusinessID",
                principalSchema: "Admin",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batch_Crop_CropID",
                schema: "Grow",
                table: "Batch",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crop",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Cultivar_CultivarID",
                schema: "Grow",
                table: "Crop",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivar",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crop",
                column: "FieldLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop",
                column: "GreenhouseLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crop",
                column: "RoomLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Locations_RowLocationID",
                schema: "Grow",
                table: "Crop",
                column: "RowLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Species_SpeciesID",
                schema: "Grow",
                table: "Crop",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Strains_StrainID",
                schema: "Grow",
                table: "Crop",
                column: "StrainID",
                principalSchema: "Grow",
                principalTable: "Strains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crop_Variety_VarietyID",
                schema: "Grow",
                table: "Crop",
                column: "VarietyID",
                principalSchema: "Grow",
                principalTable: "Variety",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivar_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivar",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_OffsiteLocation_AddressID",
                table: "Locations",
                column: "OffsiteLocation_AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Icons_IconID",
                table: "Locations",
                column: "IconID",
                principalSchema: "Admin",
                principalTable: "Icons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Transfers_TransferID",
                schema: "Grow",
                table: "PlantEvents",
                column: "TransferID",
                principalSchema: "Inventory",
                principalTable: "Transfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Crop_CropID",
                schema: "Inventory",
                table: "Plants",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crop",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Planting_PlantingID",
                table: "ProductItems",
                column: "PlantingID",
                principalSchema: "Grow",
                principalTable: "Planting",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderID",
                table: "ProductItems",
                column: "SalesOrderID",
                principalSchema: "Inventory",
                principalTable: "SalesOrders",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_Resources_ResourceID",
                schema: "Inventory",
                table: "StockItems",
                column: "ResourceID",
                principalSchema: "Inventory",
                principalTable: "Resources",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferID",
                schema: "Inventory",
                table: "TransferApprovals",
                column: "TransferID",
                principalSchema: "Inventory",
                principalTable: "Transfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_DestinationID",
                schema: "Inventory",
                table: "Transfers",
                column: "DestinationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Locations_OriginID",
                schema: "Inventory",
                table: "Transfers",
                column: "OriginID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_StockItems_StockItemID",
                schema: "Inventory",
                table: "Transfers",
                column: "StockItemID",
                principalSchema: "Inventory",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Businesses_BusinessID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Batch_Crop_CropID",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Cultivar_CultivarID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Locations_RowLocationID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Species_SpeciesID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Strains_StrainID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Crop_Variety_VarietyID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropForeignKey(
                name: "FK_Cultivar_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivar");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_OffsiteLocation_AddressID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Icons_IconID",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Transfers_TransferID",
                schema: "Grow",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Crop_CropID",
                schema: "Inventory",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Planting_PlantingID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_SalesOrders_SalesOrderID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockItems_Resources_ResourceID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropForeignKey(
                name: "FK_TransferApprovals_Transfers_TransferID",
                schema: "Inventory",
                table: "TransferApprovals");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_AspNetUsers_UserID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_DestinationID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Locations_OriginID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_StockItems_StockItemID",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "IconIconCollection",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "Planting",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "PurchaseOrderStockItem",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "SalesOrders",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "PurchaseOrder",
                schema: "Inventory");

            migrationBuilder.DropTable(
                name: "Categories",
                schema: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_PlantingID",
                table: "ProductItems");

            migrationBuilder.DropIndex(
                name: "IX_Locations_IconID",
                table: "Locations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variety",
                schema: "Grow",
                table: "Variety");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transfers",
                schema: "Inventory",
                table: "Transfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cultivar",
                schema: "Grow",
                table: "Cultivar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crop",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropIndex(
                name: "IX_Crop_CultivarID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropIndex(
                name: "IX_Crop_Name",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropIndex(
                name: "IX_Crop_VarietyID",
                schema: "Grow",
                table: "Crop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Batch",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.DropIndex(
                name: "IX_Batch_BatchName",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PlantingID",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "IconID",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "SalesOrderID",
                schema: "Grow",
                table: "Batch");

            migrationBuilder.RenameTable(
                name: "UoMs",
                schema: "Admin",
                newName: "UoMs");

            migrationBuilder.RenameTable(
                name: "TransferApprovals",
                schema: "Inventory",
                newName: "TransferApprovals");

            migrationBuilder.RenameTable(
                name: "Strains",
                schema: "Grow",
                newName: "Strains");

            migrationBuilder.RenameTable(
                name: "StockItems",
                schema: "Inventory",
                newName: "StockItems");

            migrationBuilder.RenameTable(
                name: "Species",
                schema: "Grow",
                newName: "Species");

            migrationBuilder.RenameTable(
                name: "Plants",
                schema: "Inventory",
                newName: "Plants");

            migrationBuilder.RenameTable(
                name: "PlantEvents",
                schema: "Grow",
                newName: "PlantEvents");

            migrationBuilder.RenameTable(
                name: "Lights",
                schema: "Inventory",
                newName: "Lights");

            migrationBuilder.RenameTable(
                name: "Inputs",
                schema: "Admin",
                newName: "Inputs");

            migrationBuilder.RenameTable(
                name: "Icons",
                schema: "Admin",
                newName: "Icons",
                newSchema: "Map");

            migrationBuilder.RenameTable(
                name: "IconCollections",
                schema: "Admin",
                newName: "IconCollections",
                newSchema: "Map");

            migrationBuilder.RenameTable(
                name: "DurableItems",
                schema: "Inventory",
                newName: "DurableItems");

            migrationBuilder.RenameTable(
                name: "ContainerTypes",
                schema: "Admin",
                newName: "ContainerTypes");

            migrationBuilder.RenameTable(
                name: "Consumables",
                schema: "Inventory",
                newName: "Consumables");

            migrationBuilder.RenameTable(
                name: "Businesses",
                schema: "Admin",
                newName: "Businesses");

            migrationBuilder.RenameTable(
                name: "Variety",
                schema: "Grow",
                newName: "Varieties");

            migrationBuilder.RenameTable(
                name: "Transfers",
                schema: "Inventory",
                newName: "InventoryTransfers");

            migrationBuilder.RenameTable(
                name: "Cultivar",
                schema: "Grow",
                newName: "Cultivars");

            migrationBuilder.RenameTable(
                name: "Crop",
                schema: "Grow",
                newName: "Crops");

            migrationBuilder.RenameTable(
                name: "Batch",
                schema: "Grow",
                newName: "Batches");

            migrationBuilder.RenameTable(
                name: "Address",
                schema: "Admin",
                newName: "Addresses");

            migrationBuilder.RenameColumn(
                name: "SalesOrderID",
                table: "ProductItems",
                newName: "CropID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_SalesOrderID",
                table: "ProductItems",
                newName: "IX_ProductItems_CropID");

            migrationBuilder.RenameColumn(
                name: "ResourceID",
                table: "StockItems",
                newName: "InventoryItemID");

            migrationBuilder.RenameIndex(
                name: "IX_StockItems_ResourceID",
                table: "StockItems",
                newName: "IX_StockItems_InventoryItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_UserID",
                table: "InventoryTransfers",
                newName: "IX_InventoryTransfers_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_StockItemID",
                table: "InventoryTransfers",
                newName: "IX_InventoryTransfers_StockItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_OriginID",
                table: "InventoryTransfers",
                newName: "IX_InventoryTransfers_OriginID");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationID",
                table: "InventoryTransfers",
                newName: "IX_InventoryTransfers_DestinationID");

            migrationBuilder.RenameIndex(
                name: "IX_Cultivar_SpeciesID",
                table: "Cultivars",
                newName: "IX_Cultivars_SpeciesID");

            migrationBuilder.RenameColumn(
                name: "VarietyID",
                table: "Crops",
                newName: "LocationID");

            migrationBuilder.RenameColumn(
                name: "CultivarID",
                table: "Crops",
                newName: "ExpectedVegDays");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_StrainID",
                table: "Crops",
                newName: "IX_Crops_StrainID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_SpeciesID",
                table: "Crops",
                newName: "IX_Crops_SpeciesID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_RowLocationID",
                table: "Crops",
                newName: "IX_Crops_RowLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_RoomLocationID",
                table: "Crops",
                newName: "IX_Crops_RoomLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_GreenhouseLocationID",
                table: "Crops",
                newName: "IX_Crops_GreenhouseLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Crop_FieldLocationID",
                table: "Crops",
                newName: "IX_Crops_FieldLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_Batch_CropID",
                table: "Batches",
                newName: "IX_Batches_CropID");

            migrationBuilder.RenameIndex(
                name: "IX_Address_BusinessID",
                table: "Addresses",
                newName: "IX_Addresses_BusinessID");

            migrationBuilder.AlterColumn<int>(
                name: "StrainID",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SpeciesID",
                table: "Crops",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crops",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "BatchID",
                table: "Crops",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentPhase",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ExpectedFlowerDays",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "WasteQuantity",
                table: "Crops",
                type: "decimal(10,2)",
                precision: 10,
                scale: 2,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WasteQuantityUoM",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Varieties",
                table: "Varieties",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryTransfers",
                table: "InventoryTransfers",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cultivars",
                table: "Cultivars",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crops",
                table: "Crops",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Batches",
                table: "Batches",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "IconCollectionMapIcon",
                schema: "Map",
                columns: table => new
                {
                    CollectionsID = table.Column<int>(type: "int", nullable: false),
                    IconsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IconCollectionMapIcon", x => new { x.CollectionsID, x.IconsID });
                    table.ForeignKey(
                        name: "FK_IconCollectionMapIcon_IconCollections_CollectionsID",
                        column: x => x.CollectionsID,
                        principalSchema: "Map",
                        principalTable: "IconCollections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IconCollectionMapIcon_Icons_IconsID",
                        column: x => x.IconsID,
                        principalSchema: "Map",
                        principalTable: "Icons",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    HexColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TextColor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategories", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryCategories_InventoryCategories_ParentID",
                        column: x => x.ParentID,
                        principalTable: "InventoryCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DefaultUoM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NeedsTransferApproval = table.Column<bool>(type: "bit", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: true),
                    StockType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StockUoM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryItems_InventoryCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "InventoryCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crops_BatchID",
                table: "Crops",
                column: "BatchID",
                unique: true,
                filter: "[BatchID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_Name",
                table: "Crops",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_IconCollectionMapIcon_IconsID",
                schema: "Map",
                table: "IconCollectionMapIcon",
                column: "IconsID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_Name",
                table: "InventoryCategories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_ParentID",
                table: "InventoryCategories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryID",
                table: "InventoryItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_Name",
                table: "InventoryItems",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_SKU",
                table: "InventoryItems",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Businesses_BusinessID",
                table: "Addresses",
                column: "BusinessID",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Crops_CropID",
                table: "Batches",
                column: "CropID",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                table: "Crops",
                column: "FieldLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                table: "Crops",
                column: "GreenhouseLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                table: "Crops",
                column: "RoomLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                table: "Crops",
                column: "RowLocationID",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                table: "Crops",
                column: "SpeciesID",
                principalTable: "Species",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Strains_StrainID",
                table: "Crops",
                column: "StrainID",
                principalTable: "Strains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivars_Species_SpeciesID",
                table: "Cultivars",
                column: "SpeciesID",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_UserID",
                table: "InventoryTransfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_Locations_DestinationID",
                table: "InventoryTransfers",
                column: "DestinationID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_Locations_OriginID",
                table: "InventoryTransfers",
                column: "OriginID",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_StockItems_StockItemID",
                table: "InventoryTransfers",
                column: "StockItemID",
                principalTable: "StockItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_AddressID",
                table: "Locations",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Addresses_OffsiteLocation_AddressID",
                table: "Locations",
                column: "OffsiteLocation_AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                principalTable: "InventoryTransfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Crops_CropID",
                table: "Plants",
                column: "CropID",
                principalTable: "Crops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Crops_CropID",
                table: "ProductItems",
                column: "CropID",
                principalTable: "Crops",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StockItems_InventoryItems_InventoryItemID",
                table: "StockItems",
                column: "InventoryItemID",
                principalTable: "InventoryItems",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TransferApprovals_InventoryTransfers_TransferID",
                table: "TransferApprovals",
                column: "TransferID",
                principalTable: "InventoryTransfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
