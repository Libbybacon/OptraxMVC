using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class MapPointLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressID2",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                schema: "Map",
                table: "Points",
                newName: "AddressId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "Map",
                table: "MapObjects",
                type: "int",
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
                name: "MapPointId",
                schema: "Admin",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                schema: "Admin",
                table: "Address",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_MapPointId",
                schema: "Admin",
                table: "Address",
                column: "MapPointId",
                unique: true,
                filter: "[MapPointId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_SiteId",
                schema: "Admin",
                table: "Address",
                column: "SiteId",
                unique: true,
                filter: "[SiteId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Locations_SiteId",
                schema: "Admin",
                table: "Address",
                column: "SiteId",
                principalSchema: "Admin",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Points_MapPointId",
                schema: "Admin",
                table: "Address",
                column: "MapPointId",
                principalSchema: "Map",
                principalTable: "Points",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Locations_SiteId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Points_MapPointId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_MapPointId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_SiteId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LocationId",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "Latitude",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Longitude",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "MapPointId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "SiteId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "AddressId",
                schema: "Map",
                table: "Points",
                newName: "LocationId");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                schema: "Map",
                table: "Polygons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId2",
                schema: "Admin",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Address_AddressId2",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
