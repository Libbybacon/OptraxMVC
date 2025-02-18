using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContainerTypes",
                columns: table => new
                {
                    ContainerTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    CapacityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContainerTypes", x => x.ContainerTypeID);
                });

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
                    table.ForeignKey(
                        name: "FK_InventoryCategories_InventoryCategories_ParentID",
                        column: x => x.ParentID,
                        principalTable: "InventoryCategories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "LightTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PPF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    PPFD = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    BulbType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorSpectrum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoverageAreaSF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    LifespanHours = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightTypes", x => x.ID);
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
                    Generation = table.Column<int>(type: "int", nullable: true),
                    OriginID = table.Column<int>(type: "int", nullable: true),
                    OriginType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessID = table.Column<int>(type: "int", nullable: true),
                    BuildingID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_Businesses_BusinessID",
                        column: x => x.BusinessID,
                        principalTable: "Businesses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    StockItemType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DefaultUOM = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SellerID = table.Column<int>(type: "int", nullable: true),
                    LightTypeID = table.Column<int>(type: "int", nullable: true),
                    ContainerTypeID = table.Column<int>(type: "int", nullable: true),
                    NeedsTransferApproval = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryItems_ContainerTypes_ContainerTypeID",
                        column: x => x.ContainerTypeID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ContainerTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_InventoryCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "InventoryCategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryItems_LightTypes_LightTypeID",
                        column: x => x.LightTypeID,
                        principalTable: "LightTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
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
                name: "StrainRelationships",
                columns: table => new
                {
                    ChildID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: false)
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
                name: "InventoryLocation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LocationType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    AddressID = table.Column<int>(type: "int", nullable: true),
                    ContainerTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLocation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryLocation_Addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLocation_ContainerTypes_ContainerTypeID",
                        column: x => x.ContainerTypeID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ContainerTypeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryLocation_InventoryLocation_ParentID",
                        column: x => x.ParentID,
                        principalTable: "InventoryLocation",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StockItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryItemID = table.Column<int>(type: "int", nullable: false),
                    PurchaseDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeedsTransferApproval = table.Column<bool>(type: "bit", nullable: false),
                    PurchasePrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockItems_InventoryItems_InventoryItemID",
                        column: x => x.InventoryItemID,
                        principalTable: "InventoryItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrainID = table.Column<int>(type: "int", nullable: false),
                    BatchID = table.Column<int>(type: "int", nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    CurrentPhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VegStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    VegEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FlowerStart = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    FlowerEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ExpectedVegDays = table.Column<int>(type: "int", nullable: true),
                    ExpectedFlowerDays = table.Column<int>(type: "int", nullable: true),
                    WasteQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    WasteQuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Crops_InventoryLocation_LocationID",
                        column: x => x.LocationID,
                        principalTable: "InventoryLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Crops_Strains_StrainID",
                        column: x => x.StrainID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UnitCount = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    UnitUOM = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consumables_StockItems_ID",
                        column: x => x.ID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DurableItems",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    MaintenanceInterval = table.Column<int>(type: "int", nullable: true),
                    MaintenanceInvervalUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastMaintenanceCheck = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DurableItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DurableItems_StockItems_ID",
                        column: x => x.ID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_InventoryLocationStockItem_InventoryLocation_LocationsID",
                        column: x => x.LocationsID,
                        principalTable: "InventoryLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLocationStockItem_StockItems_StockItemsID",
                        column: x => x.StockItemsID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransfers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockItemID = table.Column<int>(type: "int", nullable: false),
                    OriginID = table.Column<int>(type: "int", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    UnitCount = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    UnitUOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPartial = table.Column<bool>(type: "bit", nullable: false),
                    NeedsApproval = table.Column<bool>(type: "bit", nullable: false),
                    ApprovingManagerID = table.Column<int>(type: "int", nullable: true),
                    AprrovingManagerId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransfers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InventoryTransfers_AspNetUsers_AprrovingManagerId",
                        column: x => x.AprrovingManagerId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryTransfers_InventoryLocation_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "InventoryLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransfers_InventoryLocation_OriginID",
                        column: x => x.OriginID,
                        principalTable: "InventoryLocation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryTransfers_StockItems_StockItemID",
                        column: x => x.StockItemID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    FirstInstallDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LastMaintenanceCheck = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lights_StockItems_ID",
                        column: x => x.ID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    TrackingID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StrainID = table.Column<int>(type: "int", nullable: false),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    IsMother = table.Column<bool>(type: "bit", nullable: false),
                    StartPhase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CropID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Plants_Crops_CropID",
                        column: x => x.CropID,
                        principalTable: "Crops",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Plants_ParentID",
                        column: x => x.ParentID,
                        principalTable: "Plants",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_StockItems_ID",
                        column: x => x.ID,
                        principalTable: "StockItems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Plants_Strains_StrainID",
                        column: x => x.StrainID,
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ProductItems_InventoryLocation_InventoryLocationID",
                        column: x => x.InventoryLocationID,
                        principalTable: "InventoryLocation",
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
                name: "PlantEvents",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EventType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    EventSubType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NewPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewLightID = table.Column<int>(type: "int", nullable: true),
                    PruneType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WasteQuantity = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    WasteQuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferID = table.Column<int>(type: "int", nullable: true),
                    NewContainerID = table.Column<int>(type: "int", nullable: true),
                    TreatmentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    QuantityApplied = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    QuantityUOM = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantEvents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantEvents_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Consumables_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Consumables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantEvents_ContainerTypes_NewContainerID",
                        column: x => x.NewContainerID,
                        principalTable: "ContainerTypes",
                        principalColumn: "ContainerTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantEvents_InventoryTransfers_TransferID",
                        column: x => x.TransferID,
                        principalTable: "InventoryTransfers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Lights_NewLightID",
                        column: x => x.NewLightID,
                        principalTable: "Lights",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantEvents_Plants_PlantID",
                        column: x => x.PlantID,
                        principalTable: "Plants",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BusinessID",
                table: "Addresses",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_LocationID",
                table: "Crops",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_StrainID",
                table: "Crops",
                column: "StrainID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryCategories_ParentID",
                table: "InventoryCategories",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_CategoryID",
                table: "InventoryItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ContainerTypeID",
                table: "InventoryItems",
                column: "ContainerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_LightTypeID",
                table: "InventoryItems",
                column: "LightTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_SKU",
                table: "InventoryItems",
                column: "SKU",
                unique: true,
                filter: "[SKU] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocation_AddressID",
                table: "InventoryLocation",
                column: "AddressID",
                unique: true,
                filter: "[AddressID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocation_ContainerTypeID",
                table: "InventoryLocation",
                column: "ContainerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocation_ParentID",
                table: "InventoryLocation",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocationStockItem_StockItemsID",
                table: "InventoryLocationStockItem",
                column: "StockItemsID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_AprrovingManagerId",
                table: "InventoryTransfers",
                column: "AprrovingManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_DestinationID",
                table: "InventoryTransfers",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_OriginID",
                table: "InventoryTransfers",
                column: "OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_StockItemID",
                table: "InventoryTransfers",
                column: "StockItemID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_EmployeeId",
                table: "PlantEvents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_NewContainerID",
                table: "PlantEvents",
                column: "NewContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_NewLightID",
                table: "PlantEvents",
                column: "NewLightID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_PlantID",
                table: "PlantEvents",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_ProductID",
                table: "PlantEvents",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                unique: true,
                filter: "[TransferID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CropID",
                table: "Plants",
                column: "CropID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ParentID",
                table: "Plants",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_StrainID",
                table: "Plants",
                column: "StrainID");

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
                name: "IX_StockItems_InventoryItemID",
                table: "StockItems",
                column: "InventoryItemID");

            migrationBuilder.CreateIndex(
                name: "IX_StrainRelationships_ChildID",
                table: "StrainRelationships",
                column: "ChildID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DurableItems");

            migrationBuilder.DropTable(
                name: "InventoryLocationStockItem");

            migrationBuilder.DropTable(
                name: "PlantEvents");

            migrationBuilder.DropTable(
                name: "ProductItems");

            migrationBuilder.DropTable(
                name: "StrainRelationships");

            migrationBuilder.DropTable(
                name: "AspNetRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "InventoryTransfers");

            migrationBuilder.DropTable(
                name: "Lights");

            migrationBuilder.DropTable(
                name: "Plants");

            migrationBuilder.DropTable(
                name: "ProductBatches");

            migrationBuilder.DropTable(
                name: "AspNetUsers",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "StockItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "InventoryLocation");

            migrationBuilder.DropTable(
                name: "Strains");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ContainerTypes");

            migrationBuilder.DropTable(
                name: "InventoryCategories");

            migrationBuilder.DropTable(
                name: "LightTypes");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
