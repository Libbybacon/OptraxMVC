using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSpeciesCultivarVarietyBatchTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_ContainerTypes_ContainerTypeID",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_LightTypes_LightTypeID",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_ContainerTypes_ContainerTypeID",
                table: "InventoryLocations");

            migrationBuilder.DropTable(
                name: "LightTypes");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_ContainerTypeID",
                table: "InventoryItems");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_LightTypeID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "IsMother",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MotherName",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "ContainerTypeID",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "LightTypeID",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "OriginType",
                table: "Plants",
                newName: "PropagationType");

            migrationBuilder.RenameColumn(
                name: "ContainerTypeID",
                table: "InventoryLocations",
                newName: "SiteLocation_BusinessID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocations_ContainerTypeID",
                table: "InventoryLocations",
                newName: "IX_InventoryLocations_SiteLocation_BusinessID");

            migrationBuilder.AddColumn<int>(
                name: "BusinessID",
                table: "InventoryLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "InventoryLocations",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OffsiteLocation_AddressID",
                table: "InventoryLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OffsiteLocation_BusinessID",
                table: "InventoryLocations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldLocationID",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GreenhouseLocationID",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowLocationID",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "Batches",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropagationType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batches", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Species",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pinch = table.Column<bool>(type: "bit", nullable: true),
                    Branching = table.Column<bool>(type: "bit", nullable: true),
                    BloomSizeDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloomShape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StemLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloralCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantHeight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spread = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeafCategory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInvasive = table.Column<bool>(type: "bit", nullable: true),
                    HardinessZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BestPlantingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToMaturity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloomPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropagationTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterNeedsQty = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    WaterNeedsFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrainageNeeds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealDayTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealNightTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealSoilTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealHumidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealLightHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealpH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainPropagationMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeedDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeedStorageDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeedLifespan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColdStratify = table.Column<bool>(type: "bit", nullable: true),
                    ColdStratifyDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardenOff = table.Column<bool>(type: "bit", nullable: true),
                    HardenOffDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeedOrBulbDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestSignifiers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxStorageDays = table.Column<int>(type: "int", nullable: true),
                    StorageTemperature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaseLife = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropRotationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonPests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanionPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvoidPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attracts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resistances = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RiskFactors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Varieties",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varieties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cultivars",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesID = table.Column<int>(type: "int", nullable: false),
                    Patented = table.Column<bool>(type: "bit", nullable: false),
                    PatentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivars", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cultivars_Species_SpeciesID",
                        column: x => x.SpeciesID,
                        principalTable: "Species",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_BusinessID",
                table: "InventoryLocations",
                column: "BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_OffsiteLocation_AddressID",
                table: "InventoryLocations",
                column: "OffsiteLocation_AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_OffsiteLocation_BusinessID",
                table: "InventoryLocations",
                column: "OffsiteLocation_BusinessID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FieldLocationID",
                table: "Crops",
                column: "FieldLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_GreenhouseLocationID",
                table: "Crops",
                column: "GreenhouseLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_RowLocationID",
                table: "Crops",
                column: "RowLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivars_SpeciesID",
                table: "Cultivars",
                column: "SpeciesID");

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
                name: "FK_Crops_InventoryLocations_RowLocationID",
                table: "Crops",
                column: "RowLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Addresses_OffsiteLocation_AddressID",
                table: "InventoryLocations",
                column: "OffsiteLocation_AddressID",
                principalTable: "Addresses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Businesses_BusinessID",
                table: "InventoryLocations",
                column: "BusinessID",
                principalTable: "Businesses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Businesses_OffsiteLocation_BusinessID",
                table: "InventoryLocations",
                column: "OffsiteLocation_BusinessID",
                principalTable: "Businesses",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Businesses_SiteLocation_BusinessID",
                table: "InventoryLocations",
                column: "SiteLocation_BusinessID",
                principalTable: "Businesses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_FieldLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_GreenhouseLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_RowLocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Addresses_OffsiteLocation_AddressID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Businesses_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Businesses_OffsiteLocation_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Businesses_SiteLocation_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropTable(
                name: "Batches");

            migrationBuilder.DropTable(
                name: "Cultivars");

            migrationBuilder.DropTable(
                name: "Varieties");

            migrationBuilder.DropTable(
                name: "Species");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_OffsiteLocation_AddressID",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_OffsiteLocation_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FieldLocationID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_GreenhouseLocationID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_RowLocationID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "OffsiteLocation_AddressID",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "OffsiteLocation_BusinessID",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "FieldLocationID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "GreenhouseLocationID",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RowLocationID",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "PropagationType",
                table: "Plants",
                newName: "OriginType");

            migrationBuilder.RenameColumn(
                name: "SiteLocation_BusinessID",
                table: "InventoryLocations",
                newName: "ContainerTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocations_SiteLocation_BusinessID",
                table: "InventoryLocations",
                newName: "IX_InventoryLocations_ContainerTypeID");

            migrationBuilder.AddColumn<bool>(
                name: "IsMother",
                table: "Plants",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MotherName",
                table: "Plants",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContainerTypeID",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightTypeID",
                table: "InventoryItems",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LightTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BulbType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ColorSpectrum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoverageAreaSF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    LifespanHours = table.Column<int>(type: "int", nullable: true),
                    PPF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    PPFD = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LightTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ContainerTypeID",
                table: "InventoryItems",
                column: "ContainerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_LightTypeID",
                table: "InventoryItems",
                column: "LightTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_ContainerTypes_ContainerTypeID",
                table: "InventoryItems",
                column: "ContainerTypeID",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_LightTypes_LightTypeID",
                table: "InventoryItems",
                column: "LightTypeID",
                principalTable: "LightTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_ContainerTypes_ContainerTypeID",
                table: "InventoryLocations",
                column: "ContainerTypeID",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
