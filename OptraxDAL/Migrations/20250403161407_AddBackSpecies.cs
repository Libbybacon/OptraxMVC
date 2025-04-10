using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddBackSpecies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Species",
                schema: "Grow",
                columns: table => new
                {
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeciesName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommonName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbreviation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlantingDepth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowSpacing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blooms = table.Column<bool>(type: "bit", nullable: false),
                    Fruits = table.Column<bool>(type: "bit", nullable: false),
                    Seeds = table.Column<bool>(type: "bit", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Spread = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seasons = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardinessZone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlantingMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cycle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysToMaturity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestPeriod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropagationTypes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaterNeedsQty = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    WaterQtyUOM = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    WaterNeedsFrequency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoilDrainage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealAirTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealSoilTemp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealHumidity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealLightHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdealpH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropagationMethods = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GerminationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HardenOff = table.Column<bool>(type: "bit", nullable: true),
                    HardenOffDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestSignifiers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HarvestDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CropRotationDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonPests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommonDiseases = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanionPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvoidPlants = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attracts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Repels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CultivarID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Species", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Species_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Species_Cultivars_CultivarID",
                        column: x => x.CultivarID,
                        principalSchema: "Grow",
                        principalTable: "Cultivars",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Species_UoMs_WaterQtyUOM",
                        column: x => x.WaterQtyUOM,
                        principalSchema: "Admin",
                        principalTable: "UoMs",
                        principalColumn: "UnitName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Crops_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_CultivarID",
                schema: "Grow",
                table: "Species",
                column: "CultivarID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_SpeciesName",
                schema: "Grow",
                table: "Species",
                column: "SpeciesName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Species_UserID",
                schema: "Grow",
                table: "Species",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_WaterQtyUOM",
                schema: "Grow",
                table: "Species",
                column: "WaterQtyUOM");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropTable(
                name: "Species",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_Crops_SpeciesID",
                schema: "Grow",
                table: "Crops");
        }
    }
}
