using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class LatLngToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.AddColumn<int>(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Plantings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlantingPatternID",
                schema: "Grow",
                table: "Plantings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                schema: "Admin",
                table: "Address",
                type: "decimal(12,8)",
                precision: 12,
                scale: 8,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                schema: "Admin",
                table: "Address",
                type: "decimal(12,8)",
                precision: 12,
                scale: 8,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteID",
                schema: "Admin",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlantingPatterns",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationID = table.Column<int>(type: "int", nullable: false),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldLocationID = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_PlantingPatterns_Locations_FieldLocationID",
                        column: x => x.FieldLocationID,
                        principalSchema: "Admin",
                        principalTable: "Locations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plantings_FieldLocationID",
                schema: "Grow",
                table: "Plantings",
                column: "FieldLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Plantings_PlantingPatternID",
                schema: "Grow",
                table: "Plantings",
                column: "PlantingPatternID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPatterns_FieldLocationID",
                schema: "Grow",
                table: "PlantingPatterns",
                column: "FieldLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantingPatterns_UserID",
                schema: "Grow",
                table: "PlantingPatterns",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_Locations_FieldLocationID",
                schema: "Grow",
                table: "Plantings",
                column: "FieldLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Plantings_PlantingPatterns_PlantingPatternID",
                schema: "Grow",
                table: "Plantings",
                column: "PlantingPatternID",
                principalSchema: "Grow",
                principalTable: "PlantingPatterns",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_Locations_FieldLocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropForeignKey(
                name: "FK_Plantings_PlantingPatterns_PlantingPatternID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropTable(
                name: "PlantingPatterns",
                schema: "Grow");

            migrationBuilder.DropIndex(
                name: "IX_Plantings_FieldLocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropIndex(
                name: "IX_Plantings_PlantingPatternID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "PlantingPatternID",
                schema: "Grow",
                table: "Plantings");

            migrationBuilder.DropColumn(
                name: "Classification",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "SiteID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.AddColumn<int>(
                name: "FieldLocationID",
                schema: "Grow",
                table: "Crops",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressID2",
                schema: "Admin",
                table: "Locations",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                column: "FieldLocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Locations_FieldLocationID",
                schema: "Grow",
                table: "Crops",
                column: "FieldLocationID",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations",
                column: "AddressID",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "ID");
        }
    }
}
