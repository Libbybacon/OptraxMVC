using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMapObjectsUpdateLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_FieldLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_GreenhouseLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_LocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_RowLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Strains_StrainID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_DestinationID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_OriginID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Lights_NewLightID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Strains_StrainID",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_InventoryLocations_InventoryLocationID",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "InventoryLocationStockItem");

            migrationBuilder.DropTable(
                name: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_NewLightID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_Crops_LocationID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "NewLightID",
                table: "PlantEvents");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "FlowerEnd",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "FlowerStart",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "VegEnd",
                table: "Crops");

            migrationBuilder.EnsureSchema(
                name: "Map");

            migrationBuilder.RenameColumn(
                name: "InventoryLocationID",
                table: "ProductItems",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_InventoryLocationID",
                table: "ProductItems",
                newName: "IX_ProductItems_LocationID");

            migrationBuilder.RenameColumn(
                name: "VegStart",
                table: "Crops",
                newName: "DateLastModified");

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Varieties",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Varieties",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesID",
                table: "Varieties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Strains",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Strains",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "StockItems",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "StockItems",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                table: "Species",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "Pinch",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Branching",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Species",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Species",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Products",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "ProductBatches",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "ProductBatches",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StrainID",
                table: "Plants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesID",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VarietyID",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "InventoryItems",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "InventoryItems",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "InventoryItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "InventoryCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "InventoryCategories",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "InventoryCategories",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "InventoryCategories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Cultivars",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Cultivars",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Crops",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomLocationID",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesID",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessType",
                table: "Businesses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Businesses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Businesses",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BatchName",
                table: "Batches",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Batches",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CropID",
                table: "Batches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Batches",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Batches",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Batches",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginType",
                table: "Batches",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Addresses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                table: "Addresses",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedByID",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MapObjects",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObjectType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjectCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapObjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lines",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LineGeometry = table.Column<LineString>(type: "geometry", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lines_MapObjects_ID",
                        column: x => x.ID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapObjectID = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Level = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    BusinessID = table.Column<int>(type: "int", nullable: true),
                    OffsiteLocation_AddressID = table.Column<int>(type: "int", nullable: true),
                    OffsiteLocation_BusinessID = table.Column<int>(type: "int", nullable: true),
                    IsPrimary = table.Column<bool>(type: "bit", nullable: true),
                    SiteLocation_BusinessID = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastModifiedByID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Addresses_OffsiteLocation_AddressID",
                        column: x => x.OffsiteLocation_AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Businesses_OffsiteLocation_BusinessID",
                        column: x => x.OffsiteLocation_BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_Businesses_SiteLocation_BusinessID",
                        column: x => x.SiteLocation_BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Locations_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Locations_MapObjects_MapObjectID",
                        column: x => x.MapObjectID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LocationStockItem",
                columns: table => new
                {
                    LocationsID = table.Column<int>(type: "int", nullable: false),
                    StockItemsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationStockItem", x => new { x.LocationsID, x.StockItemsID });
                    table.ForeignKey(
                        name: "FK_LocationStockItem_Locations_LocationsID",
                        column: x => x.LocationsID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationStockItem_StockItems_StockItemsID",
                        column: x => x.StockItemsID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Polygons",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    BorderWidth = table.Column<int>(type: "int", nullable: false),
                    BorderColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FillColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolyGeometry = table.Column<Polygon>(type: "geometry", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polygons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Polygons_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Polygons_MapObjects_ID",
                        column: x => x.ID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    MapLineID = table.Column<int>(type: "int", nullable: true),
                    MapPolygonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Points_Lines_MapLineID",
                        column: x => x.MapLineID,
                        principalSchema: "Map",
                        principalTable: "Lines",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Points_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Points_MapObjects_ID",
                        column: x => x.ID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Points_Polygons_MapPolygonID",
                        column: x => x.MapPolygonID,
                        principalSchema: "Map",
                        principalTable: "Polygons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesName",
                table: "Species",
                column: "SpeciesName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crops_RoomLocationID",
                table: "Crops",
                column: "RoomLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_SpeciesID",
                table: "Crops",
                column: "SpeciesID");

            migrationBuilder.CreateIndex(
                name: "IX_Batches_CropID",
                table: "Batches",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_InputName",
                table: "Inputs",
                column: "InputName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressID",
                table: "Locations",
                column: "AddressID",
                unique: true,
                filter: "[AddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_BusinessID",
                table: "Locations",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapObjectID",
                table: "Locations",
                column: "MapObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Name",
                table: "Locations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OffsiteLocation_AddressID",
                table: "Locations",
                column: "OffsiteLocation_AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_OffsiteLocation_BusinessID",
                table: "Locations",
                column: "OffsiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ParentID",
                table: "Locations",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_SiteLocation_BusinessID",
                table: "Locations",
                column: "SiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationStockItem_StockItemsID",
                table: "LocationStockItem",
                column: "StockItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_LocationID",
                schema: "Map",
                table: "Points",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_MapLineID",
                schema: "Map",
                table: "Points",
                column: "MapLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_MapPolygonID",
                schema: "Map",
                table: "Points",
                column: "MapPolygonID");

            migrationBuilder.CreateIndex(
                name: "IX_Polygons_LocationID",
                schema: "Map",
                table: "Polygons",
                column: "LocationID");

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
                name: "FK_Plants_Strains_StrainID",
                table: "Plants",
                column: "StrainID",
                principalTable: "Strains",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Locations_LocationID",
                table: "ProductItems",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_InventoryTransfers_Locations_DestinationID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_Locations_OriginID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Strains_StrainID",
                table: "Plants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Locations_LocationID",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "LocationStockItem");

            migrationBuilder.DropTable(
                name: "Points",
                schema: "Map");

            migrationBuilder.DropTable(
                name: "Lines",
                schema: "Map");

            migrationBuilder.DropTable(
                name: "Polygons",
                schema: "Map");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "MapObjects",
                schema: "Map");

            migrationBuilder.DropIndex(
                name: "IX_Species_SpeciesName",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Crops_RoomLocationID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_SpeciesID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Batches_CropID",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "SpeciesID",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "SpeciesID",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "VarietyID",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "InventoryCategories");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "InventoryCategories");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "InventoryCategories");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "InventoryCategories");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RoomLocationID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "SpeciesID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CropID",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "OriginType",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "LastModifiedByID",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "ProductItems",
                newName: "InventoryLocationID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductItems_LocationID",
                table: "ProductItems",
                newName: "IX_ProductItems_InventoryLocationID");

            migrationBuilder.RenameColumn(
                name: "DateLastModified",
                table: "Crops",
                newName: "VegStart");

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<bool>(
                name: "Pinch",
                table: "Species",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "Branching",
                table: "Species",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "StrainID",
                table: "Plants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NewLightID",
                table: "PlantEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EndDate",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FlowerEnd",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "FlowerStart",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "StartDate",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "VegEnd",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BusinessType",
                table: "Businesses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "BatchName",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "InventoryLocations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Level = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    BusinessID = table.Column<int>(type: "int", nullable: true),
                    OffsiteLocation_AddressID = table.Column<int>(type: "int", nullable: true),
                    OffsiteLocation_BusinessID = table.Column<int>(type: "int", nullable: true),
                    SiteLocation_BusinessID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLocations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Addresses_OffsiteLocation_AddressID",
                        column: x => x.OffsiteLocation_AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Businesses_OffsiteLocation_BusinessID",
                        column: x => x.OffsiteLocation_BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_InventoryLocations_Businesses_SiteLocation_BusinessID",
                        column: x => x.SiteLocation_BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLocations_InventoryLocations_ParentID",
                        column: x => x.ParentID,
                        principalTable: "InventoryLocations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InventoryLocationStockItem",
                columns: table => new
                {
                    LocationsID = table.Column<int>(type: "int", nullable: false),
                    StockItemsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLocationStockItem", x => new { x.LocationsID, x.StockItemsID });
                    table.ForeignKey(
                        name: "FK_InventoryLocationStockItem_InventoryLocations_LocationsID",
                        column: x => x.LocationsID,
                        principalTable: "InventoryLocations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLocationStockItem_StockItems_StockItemsID",
                        column: x => x.StockItemsID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_NewLightID",
                table: "PlantEvents",
                column: "NewLightID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_LocationID",
                table: "Crops",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_AddressID",
                table: "InventoryLocations",
                column: "AddressID",
                unique: true,
                filter: "[AddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_BusinessID",
                table: "InventoryLocations",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_Name",
                table: "InventoryLocations",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_OffsiteLocation_AddressID",
                table: "InventoryLocations",
                column: "OffsiteLocation_AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_OffsiteLocation_BusinessID",
                table: "InventoryLocations",
                column: "OffsiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_ParentID",
                table: "InventoryLocations",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_SiteLocation_BusinessID",
                table: "InventoryLocations",
                column: "SiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocationStockItem_StockItemsID",
                table: "InventoryLocationStockItem",
                column: "StockItemsID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocations_FieldLocationID",
                table: "Crops",
                column: "FieldLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocations_GreenhouseLocationID",
                table: "Crops",
                column: "GreenhouseLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocations_LocationID",
                table: "Crops",
                column: "LocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocations_RowLocationID",
                table: "Crops",
                column: "RowLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Strains_StrainID",
                table: "Crops",
                column: "StrainID",
                principalTable: "Strains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_DestinationID",
                table: "InventoryTransfers",
                column: "DestinationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_OriginID",
                table: "InventoryTransfers",
                column: "OriginID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Lights_NewLightID",
                table: "PlantEvents",
                column: "NewLightID",
                principalTable: "Lights",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Strains_StrainID",
                table: "Plants",
                column: "StrainID",
                principalTable: "Strains",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_InventoryLocations_InventoryLocationID",
                table: "ProductItems",
                column: "InventoryLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");
        }
    }
}
