using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGeogToGeom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Polygon>(
                name: "PolyGeometry",
                schema: "Map",
                table: "Polygons",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Polygon),
                oldType: "geography ");

            migrationBuilder.AlterColumn<LineString>(
                name: "LineGeometry",
                schema: "Map",
                table: "Lines",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(LineString),
                oldType: "geography ",
                oldNullable: true);

            migrationBuilder.AlterColumn<Polygon>(
                name: "Area",
                schema: "Map",
                table: "Circles",
                type: "geography",
                nullable: true,
                computedColumnSql: "geometry::Point([Longitude], [Latitude],  4326).STBuffer([Radius])",
                stored: true,
                oldClrType: typeof(Polygon),
                oldType: "geography",
                oldNullable: true,
                oldComputedColumnSql: "geography::Point([Latitude], [Longitude], 4326).STBuffer([Radius])",
                oldStored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Polygon>(
                name: "PolyGeometry",
                schema: "Map",
                table: "Polygons",
                type: "geography ",
                nullable: false,
                oldClrType: typeof(Polygon),
                oldType: "geometry");

            migrationBuilder.AlterColumn<LineString>(
                name: "LineGeometry",
                schema: "Map",
                table: "Lines",
                type: "geography ",
                nullable: true,
                oldClrType: typeof(LineString),
                oldType: "geometry",
                oldNullable: true);

            migrationBuilder.AlterColumn<Polygon>(
                name: "Area",
                schema: "Map",
                table: "Circles",
                type: "geography",
                nullable: true,
                computedColumnSql: "geography::Point([Latitude], [Longitude], 4326).STBuffer([Radius])",
                stored: true,
                oldClrType: typeof(Polygon),
                oldType: "geography",
                oldNullable: true,
                oldComputedColumnSql: "geometry::Point([Longitude], [Latitude],  4326).STBuffer([Radius])",
                oldStored: true);
        }
    }
}
