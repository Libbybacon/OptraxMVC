using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddNonIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "AspNetUserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "AspNetUserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "AspNetUserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "AspNetUserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "AspNetRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "AspNetRoleClaims",
                newSchema: "Identity");

            migrationBuilder.CreateTable(
                name: "InventoryCategories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryCategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockCount = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    StockUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLocations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLocations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductUnitUOM = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strains",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrainType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContainerTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryItemID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    CapacityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTypes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ContainerTypes_InventoryItems_InventoryItemID",
                        column: x => x.InventoryItemID,
                        principalTable: "InventoryItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStockItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryItemID = table.Column<int>(type: "int", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStockItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryStockItems_InventoryItems_InventoryItemID",
                        column: x => x.InventoryItemID,
                        principalTable: "InventoryItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryStockItems_InventoryLocations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "InventoryLocations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_InventoryLocations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "InventoryLocations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductBatches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    BatchNumber = table.Column<int>(type: "int", nullable: false),
                    UnitQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBatches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductBatches_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrainID = table.Column<int>(type: "int", nullable: false),
                    BatchID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpectedVegDays = table.Column<int>(type: "int", nullable: true),
                    ActualVegDays = table.Column<int>(type: "int", nullable: true),
                    ExpectedFlowerDays = table.Column<int>(type: "int", nullable: true),
                    ActualFlowerDays = table.Column<int>(type: "int", nullable: true),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    ProductQuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasteQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    WasteQuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Crops_Strains_StrainID",
                        column: x => x.StrainID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StrainRelationships",
                columns: table => new
                {
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    ChildID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrainRelationships", x => new { x.ParentID, x.ChildID });
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ChildID",
                        column: x => x.ChildID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryStockID = table.Column<int>(type: "int", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    PPF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    PPFD = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    BulbType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorSpectrum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoverageAreaSF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    LifespanHours = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true),
                    InventoryStockItemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lights_InventoryStockItems_InventoryStockItemID",
                        column: x => x.InventoryStockItemID,
                        principalTable: "InventoryStockItems",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lights_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    BatchID = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    InventoryLocationID = table.Column<int>(type: "int", nullable: true),
                    CropID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductItems_Crops_CropID",
                        column: x => x.CropID,
                        principalTable: "Crops",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductItems_InventoryLocations_InventoryLocationID",
                        column: x => x.InventoryLocationID,
                        principalTable: "InventoryLocations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductItems_ProductBatches_BatchID",
                        column: x => x.BatchID,
                        principalTable: "ProductBatches",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ProductItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrainID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    StartType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMother = table.Column<bool>(type: "bit", nullable: false),
                    GrowthPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    LightID = table.Column<int>(type: "int", nullable: true),
                    ContainerID = table.Column<int>(type: "int", nullable: true),
                    CurrentContainerID = table.Column<int>(type: "int", nullable: true),
                    CropID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantID);
                    table.ForeignKey(
                        name: "FK_Plants_ContainerTypes_CurrentContainerID",
                        column: x => x.CurrentContainerID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Crops_CropID",
                        column: x => x.CropID,
                        principalTable: "Crops",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Lights_LightID",
                        column: x => x.LightID,
                        principalTable: "Lights",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Strains_StrainID",
                        column: x => x.StrainID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantTransfers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    ActionID = table.Column<int>(type: "int", nullable: false),
                    TransferType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginID = table.Column<int>(type: "int", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTransfers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_ContainerTypes_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_ContainerTypes_OriginID",
                        column: x => x.OriginID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Lights_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Lights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Lights_OriginID",
                        column: x => x.OriginID,
                        principalTable: "Lights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Rooms_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Rooms_OriginID",
                        column: x => x.OriginID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlantActions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActionSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PruneType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferID = table.Column<int>(type: "int", nullable: true),
                    TreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InventoryItemID = table.Column<int>(type: "int", nullable: true),
                    QuantityApplied = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    QuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantActions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantActions_InventoryStockItems_InventoryItemID",
                        column: x => x.InventoryItemID,
                        principalTable: "InventoryStockItems",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PlantActions_PlantTransfers_TransferID",
                        column: x => x.TransferID,
                        principalTable: "PlantTransfers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantActions_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_InventoryItemID",
                table: "ContainerTypes",
                column: "InventoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_StrainID",
                table: "Crops",
                column: "StrainID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStockItems_InventoryItemID",
                table: "InventoryStockItems",
                column: "InventoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStockItems_LocationID",
                table: "InventoryStockItems",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Lights_InventoryStockItemID",
                table: "Lights",
                column: "InventoryStockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Lights_RoomID",
                table: "Lights",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_InventoryItemID",
                table: "PlantActions",
                column: "InventoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_PlantID",
                table: "PlantActions",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantActions_TransferID",
                table: "PlantActions",
                column: "TransferID",
                unique: true,
                filter: "[TransferID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CropID",
                table: "Plants",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CurrentContainerID",
                table: "Plants",
                column: "CurrentContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LightID",
                table: "Plants",
                column: "LightID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_RoomID",
                table: "Plants",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_StrainID",
                table: "Plants",
                column: "StrainID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_DestinationID",
                table: "PlantTransfers",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_OriginID",
                table: "PlantTransfers",
                column: "OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_PlantID",
                table: "PlantTransfers",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBatches_ProductID",
                table: "ProductBatches",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_Barcode",
                table: "ProductItems",
                column: "Barcode",
                unique: true,
                filter: "[Barcode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_BatchID",
                table: "ProductItems",
                column: "BatchID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_CropID",
                table: "ProductItems",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_InventoryLocationID",
                table: "ProductItems",
                column: "InventoryLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_ProductID",
                table: "ProductItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LocationID",
                table: "Rooms",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_StrainRelationships_ChildID",
                table: "StrainRelationships",
                column: "ChildID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryCategories");

            migrationBuilder.DropTable(
                name: "PlantActions");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "StrainRelationships");

            migrationBuilder.DropTable(
                name: "PlantTransfers");

            migrationBuilder.DropTable(
                name: "ProductBatches");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ContainerTypes");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "Lights");

            migrationBuilder.DropTable(
                name: "Strains");

            migrationBuilder.DropTable(
                name: "InventoryStockItems");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "InventoryLocations");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                schema: "Identity",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims");
        }
    }
}
