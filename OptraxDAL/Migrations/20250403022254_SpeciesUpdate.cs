using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class SpeciesUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cultivars_Species_SpeciesID",
            //    schema: "Grow",
            //    table: "Cultivars");

            //migrationBuilder.DropIndex(
            //    name: "IX_Cultivars_SpeciesID",
            //    schema: "Grow",
            //    table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "BestPlantingMethod",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "BloomPeriod",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "BloomShape",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "BloomSizeDescription",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ColdStratify",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "ColdStratifyDetails",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "DrainageNeeds",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "FloralCategory",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "GerminationTime",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IdealDayTemp",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IdealNightTemp",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "IsInvasive",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "LeafCategory",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "MainPropagationMethod",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Notes",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "PlantHeight",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "Resistances",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "RiskFactors",
                schema: "Grow",
                table: "Species");

            migrationBuilder.RenameColumn(
                name: "VaseLife",
                schema: "Grow",
                table: "Species",
                newName: "SoilDrainage");

            migrationBuilder.RenameColumn(
                name: "Uses",
                schema: "Grow",
                table: "Species",
                newName: "PropagationMethods");

            migrationBuilder.RenameColumn(
                name: "StorageTemperature",
                schema: "Grow",
                table: "Species",
                newName: "PlantingMethods");

            migrationBuilder.RenameColumn(
                name: "StemLength",
                schema: "Grow",
                table: "Species",
                newName: "PlantingDepth");

            migrationBuilder.RenameColumn(
                name: "SeedStorageDetails",
                schema: "Grow",
                table: "Species",
                newName: "IdealAirTemp");

            migrationBuilder.RenameColumn(
                name: "SeedOrBulbDepth",
                schema: "Grow",
                table: "Species",
                newName: "Height");

            migrationBuilder.RenameColumn(
                name: "SeedLifespan",
                schema: "Grow",
                table: "Species",
                newName: "GerminationDays");

            migrationBuilder.RenameColumn(
                name: "SeedDescription",
                schema: "Grow",
                table: "Species",
                newName: "Cycle");

            migrationBuilder.RenameColumn(
                name: "Pinch",
                schema: "Grow",
                table: "Species",
                newName: "Seeds");

            migrationBuilder.RenameColumn(
                name: "MaxStorageDays",
                schema: "Grow",
                table: "Species",
                newName: "CultivarID");

            migrationBuilder.RenameColumn(
                name: "Branching",
                schema: "Grow",
                table: "Species",
                newName: "Fruits");

            migrationBuilder.RenameColumn(
                name: "SpeciesID",
                schema: "Grow",
                table: "Cultivars",
                newName: "Generation");

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Varieties",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterNeedsQty",
                schema: "Grow",
                table: "Species",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2,
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<string>(
                name: "WaterNeedsFrequency",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<string>(
                name: "Spread",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "SoilType",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<string>(
                name: "Site",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<string>(
                name: "Seasons",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<string>(
                name: "RowSpacing",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Repels",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 48);

            migrationBuilder.AlterColumn<string>(
                name: "PropagationTypes",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<string>(
                name: "PlantType",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "PlantSpacing",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "IdealpH",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 34);

            migrationBuilder.AlterColumn<string>(
                name: "IdealSoilTemp",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<string>(
                name: "IdealLightHours",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 33);

            migrationBuilder.AlterColumn<string>(
                name: "IdealHumidity",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<string>(
                name: "HeatZone",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestSignifiers",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 40);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestPeriod",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 41);

            migrationBuilder.AlterColumn<string>(
                name: "HardinessZone",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "HardenOffDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 39);

            migrationBuilder.AlterColumn<bool>(
                name: "HardenOff",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 38);

            migrationBuilder.AlterColumn<string>(
                name: "GerminationDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 37);

            migrationBuilder.AlterColumn<string>(
                name: "Genus",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "DaysToMaturity",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<string>(
                name: "CustomName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "CropRotationDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 42);

            migrationBuilder.AlterColumn<string>(
                name: "CompanionPlants",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 45);

            migrationBuilder.AlterColumn<string>(
                name: "CommonPests",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 43);

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "CommonDiseases",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 44);

            migrationBuilder.AlterColumn<string>(
                name: "AvoidPlants",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 46);

            migrationBuilder.AlterColumn<string>(
                name: "Attracts",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 47);

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "SoilDrainage",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<string>(
                name: "PropagationMethods",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 35);

            migrationBuilder.AlterColumn<string>(
                name: "PlantingMethods",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<string>(
                name: "PlantingDepth",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "IdealAirTemp",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<string>(
                name: "Height",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<string>(
                name: "GerminationDays",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<string>(
                name: "Cycle",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 22);

            migrationBuilder.AlterColumn<bool>(
                name: "Seeds",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<bool>(
                name: "Fruits",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 12);

            migrationBuilder.AddColumn<bool>(
                name: "Blooms",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 11);

            migrationBuilder.AddColumn<string>(
                name: "WaterQtyUOM",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(50)",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 27);

            migrationBuilder.AddColumn<string>(
                name: "BreedingMethod",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Cultivars",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genotype",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Hybrid",
                schema: "Grow",
                table: "Cultivars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Phenotype",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Varieties_CultivarID",
            //    schema: "Grow",
            //    table: "Varieties",
            //    column: "CultivarID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Species_CultivarID",
            //    schema: "Grow",
            //    table: "Species",
            //    column: "CultivarID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Species_WaterQtyUOM",
            //    schema: "Grow",
            //    table: "Species",
            //    column: "WaterQtyUOM");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Cultivars",
            //    column: "CultivarID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Cultivars_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Cultivars",
            //    column: "CultivarID",
            //    principalSchema: "Grow",
            //    principalTable: "Cultivars",
            //    principalColumn: "ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Species_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Species",
            //    column: "CultivarID",
            //    principalSchema: "Grow",
            //    principalTable: "Cultivars",
            //    principalColumn: "ID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Species_UoMs_WaterQtyUOM",
            //    schema: "Grow",
            //    table: "Species",
            //    column: "WaterQtyUOM",
            //    principalSchema: "Admin",
            //    principalTable: "UoMs",
            //    principalColumn: "UnitName");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Varieties_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Varieties",
            //    column: "CultivarID",
            //    principalSchema: "Grow",
            //    principalTable: "Cultivars",
            //    principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cultivars_Cultivars_CultivarID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Cultivars_CultivarID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_UoMs_WaterQtyUOM",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropForeignKey(
                name: "FK_Varieties_Cultivars_CultivarID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Varieties_CultivarID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Species_CultivarID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Species_WaterQtyUOM",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropIndex(
                name: "IX_Cultivars_CultivarID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "Blooms",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "WaterQtyUOM",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "BreedingMethod",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "Genotype",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "Hybrid",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "Phenotype",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.RenameColumn(
                name: "SoilDrainage",
                schema: "Grow",
                table: "Species",
                newName: "VaseLife");

            migrationBuilder.RenameColumn(
                name: "Seeds",
                schema: "Grow",
                table: "Species",
                newName: "Pinch");

            migrationBuilder.RenameColumn(
                name: "PropagationMethods",
                schema: "Grow",
                table: "Species",
                newName: "Uses");

            migrationBuilder.RenameColumn(
                name: "PlantingMethods",
                schema: "Grow",
                table: "Species",
                newName: "StorageTemperature");

            migrationBuilder.RenameColumn(
                name: "PlantingDepth",
                schema: "Grow",
                table: "Species",
                newName: "StemLength");

            migrationBuilder.RenameColumn(
                name: "IdealAirTemp",
                schema: "Grow",
                table: "Species",
                newName: "SeedStorageDetails");

            migrationBuilder.RenameColumn(
                name: "Height",
                schema: "Grow",
                table: "Species",
                newName: "SeedOrBulbDepth");

            migrationBuilder.RenameColumn(
                name: "GerminationDays",
                schema: "Grow",
                table: "Species",
                newName: "SeedLifespan");

            migrationBuilder.RenameColumn(
                name: "Fruits",
                schema: "Grow",
                table: "Species",
                newName: "Branching");

            migrationBuilder.RenameColumn(
                name: "Cycle",
                schema: "Grow",
                table: "Species",
                newName: "SeedDescription");

            migrationBuilder.RenameColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Species",
                newName: "MaxStorageDays");

            migrationBuilder.RenameColumn(
                name: "Generation",
                schema: "Grow",
                table: "Cultivars",
                newName: "SpeciesID");

            migrationBuilder.AlterColumn<decimal>(
                name: "WaterNeedsQty",
                schema: "Grow",
                table: "Species",
                type: "decimal(8,2)",
                precision: 8,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,2)",
                oldPrecision: 8,
                oldScale: 2,
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 26);

            migrationBuilder.AlterColumn<string>(
                name: "WaterNeedsFrequency",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 28);

            migrationBuilder.AlterColumn<string>(
                name: "Spread",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 15);

            migrationBuilder.AlterColumn<string>(
                name: "SpeciesName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.AlterColumn<string>(
                name: "SoilType",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 18);

            migrationBuilder.AlterColumn<string>(
                name: "Site",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 16);

            migrationBuilder.AlterColumn<string>(
                name: "Seasons",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 17);

            migrationBuilder.AlterColumn<string>(
                name: "RowSpacing",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 10);

            migrationBuilder.AlterColumn<string>(
                name: "Repels",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 48);

            migrationBuilder.AlterColumn<string>(
                name: "PropagationTypes",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 25);

            migrationBuilder.AlterColumn<string>(
                name: "PlantType",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 7);

            migrationBuilder.AlterColumn<string>(
                name: "PlantSpacing",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 9);

            migrationBuilder.AlterColumn<string>(
                name: "IdealpH",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 34);

            migrationBuilder.AlterColumn<string>(
                name: "IdealSoilTemp",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 31);

            migrationBuilder.AlterColumn<string>(
                name: "IdealLightHours",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 33);

            migrationBuilder.AlterColumn<string>(
                name: "IdealHumidity",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 32);

            migrationBuilder.AlterColumn<string>(
                name: "HeatZone",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 19);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestSignifiers",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 40);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestPeriod",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 24);

            migrationBuilder.AlterColumn<string>(
                name: "HarvestDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 41);

            migrationBuilder.AlterColumn<string>(
                name: "HardinessZone",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 20);

            migrationBuilder.AlterColumn<string>(
                name: "HardenOffDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 39);

            migrationBuilder.AlterColumn<bool>(
                name: "HardenOff",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 38);

            migrationBuilder.AlterColumn<string>(
                name: "GerminationDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 37);

            migrationBuilder.AlterColumn<string>(
                name: "Genus",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<string>(
                name: "Family",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 6);

            migrationBuilder.AlterColumn<string>(
                name: "DaysToMaturity",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 23);

            migrationBuilder.AlterColumn<string>(
                name: "CustomName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 4);

            migrationBuilder.AlterColumn<string>(
                name: "CropRotationDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 42);

            migrationBuilder.AlterColumn<string>(
                name: "CompanionPlants",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 45);

            migrationBuilder.AlterColumn<string>(
                name: "CommonPests",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 43);

            migrationBuilder.AlterColumn<string>(
                name: "CommonName",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 3);

            migrationBuilder.AlterColumn<string>(
                name: "CommonDiseases",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 44);

            migrationBuilder.AlterColumn<string>(
                name: "AvoidPlants",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 46);

            migrationBuilder.AlterColumn<string>(
                name: "Attracts",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 47);

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 5);

            migrationBuilder.AlterColumn<string>(
                name: "VaseLife",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 29);

            migrationBuilder.AlterColumn<bool>(
                name: "Pinch",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 13);

            migrationBuilder.AlterColumn<string>(
                name: "Uses",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 35);

            migrationBuilder.AlterColumn<string>(
                name: "StorageTemperature",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 21);

            migrationBuilder.AlterColumn<string>(
                name: "StemLength",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 8);

            migrationBuilder.AlterColumn<string>(
                name: "SeedStorageDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 30);

            migrationBuilder.AlterColumn<string>(
                name: "SeedOrBulbDepth",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 14);

            migrationBuilder.AlterColumn<string>(
                name: "SeedLifespan",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 36);

            migrationBuilder.AlterColumn<bool>(
                name: "Branching",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 12);

            migrationBuilder.AlterColumn<string>(
                name: "SeedDescription",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 22);

            migrationBuilder.AddColumn<string>(
                name: "BestPlantingMethod",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloomPeriod",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloomShape",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloomSizeDescription",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ColdStratify",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ColdStratifyDetails",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DrainageNeeds",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FloralCategory",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GerminationTime",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdealDayTemp",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdealNightTemp",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsInvasive",
                schema: "Grow",
                table: "Species",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeafCategory",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainPropagationMethod",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantHeight",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Resistances",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RiskFactors",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cultivars_SpeciesID",
                schema: "Grow",
                table: "Cultivars",
                column: "SpeciesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivars_Species_SpeciesID",
                schema: "Grow",
                table: "Cultivars",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
