using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class BigChangeroo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Locations_LocationID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Polygons_Locations_LocationID",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropIndex(
                name: "IX_Polygons_LocationID",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropIndex(
                name: "IX_Points_LocationID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_RoomLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_RowLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Level",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "GreenhouseLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RoomLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "RowLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DatePlanted",
                schema: "Grow",
                table: "Plantings",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantingMethod",
                schema: "Grow",
                table: "Plantings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Radius",
                schema: "Admin",
                table: "Locations",
                type: "decimal(18,4)",
                precision: 18,
                scale: 4,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shape",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateTable(
                name: "PlantingPatterns",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Width = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Length = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Radius = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SpaceLeft = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    SpaceRight = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    PlantSpacing = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: true),
                    Direction = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingPatterns", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantingPatterns_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlantingSections",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantingID = table.Column<int>(type: "int", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: true),
                    ParentID = table.Column<int>(type: "int", nullable: true),
                    PatternID = table.Column<int>(type: "int", nullable: false),
                    MapObjectID = table.Column<int>(type: "int", nullable: true),
                    SectionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingSections", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantingSections_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlantingSections_MapObjects_MapObjectID",
                        column: x => x.MapObjectID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantingSections_PlantingPatterns_PatternID",
                        column: x => x.PatternID,
                        principalSchema: "Grow",
                        principalTable: "PlantingPatterns",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingSections_PlantingSections_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "Grow",
                        principalTable: "PlantingSections",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantingSections_Plantings_PlantingID",
                        column: x => x.PlantingID,
                        principalSchema: "Grow",
                        principalTable: "Plantings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID",
                unique: true,
                filter: "[MapObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPatterns_UserID",
                schema: "Grow",
                table: "PlantingPatterns",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_MapObjectID",
                schema: "Grow",
                table: "PlantingSections",
                column: "MapObjectID",
                unique: true,
                filter: "[MapObjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_ParentID",
                schema: "Grow",
                table: "PlantingSections",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_PatternID",
                schema: "Grow",
                table: "PlantingSections",
                column: "PatternID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_PlantingID",
                schema: "Grow",
                table: "PlantingSections",
                column: "PlantingID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingSections_UserID",
                schema: "Grow",
                table: "PlantingSections",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops",
                column: "VarietyID",
                principalSchema: "Grow",
                principalTable: "Varieties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings",
                column: "BatchID",
                principalSchema: "Grow",
                principalTable: "Batches",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropTable(
                name: "PlantingSections",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "PlantingPatterns",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "DatePlanted",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "PlantingMethod",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "Radius",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Shape",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                schema: "Admin",
                table: "Locations",
                type: "int",
                maxLength: 1,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GreenhouseLocationID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomLocationID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RowLocationID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                schema: "Inventory",
                table: "Categories",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.CreateIndex(
                name: "IX_Polygons_LocationID",
                schema: "Map",
                table: "Polygons",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_LocationID",
                schema: "Map",
                table: "Points",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                column: "FieldLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops",
                column: "GreenhouseLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_RoomLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RoomLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_RowLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RowLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Cultivars_CultivarID",
                schema: "Grow",
                table: "Crops",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                column: "FieldLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_GreenhouseLocationID",
                schema: "Grow",
                table: "Crops",
                column: "GreenhouseLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RoomLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RoomLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_RowLocationID",
                schema: "Grow",
                table: "Crops",
                column: "RowLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Species_SpeciesID",
                schema: "Grow",
                table: "Crops",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Varieties_VarietyID",
                schema: "Grow",
                table: "Crops",
                column: "VarietyID",
                principalSchema: "Grow",
                principalTable: "Varieties",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MapObjects_MapObjectID",
                schema: "Admin",
                table: "Locations",
                column: "MapObjectID",
                principalSchema: "Map",
                principalTable: "MapObjects",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Batches_BatchID",
                schema: "Grow",
                table: "Plantings",
                column: "BatchID",
                principalSchema: "Grow",
                principalTable: "Batches",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Crops_CropID",
                schema: "Grow",
                table: "Plantings",
                column: "CropID",
                principalSchema: "Grow",
                principalTable: "Crops",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_LocationID",
                schema: "Grow",
                table: "Plantings",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Locations_LocationID",
                schema: "Map",
                table: "Points",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Polygons_Locations_LocationID",
                schema: "Map",
                table: "Polygons",
                column: "LocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");
        }
    }
}
