using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class ManuallyComputeCircleArea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Polygon>(
                name: "PolyGeometry",
                schema: "Map",
                table: "Polygons",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Polygon),
                oldType: "geometry");

            migrationBuilder.AlterColumn<Polygon>(
                name: "Area",
                schema: "Map",
                table: "Circles",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Polygon),
                oldType: "geography",
                oldNullable: true,
                oldComputedColumnSql: "geometry::Point([Longitude], [Latitude],  4326).STBuffer([Radius])");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Polygon>(
                name: "PolyGeometry",
                schema: "Map",
                table: "Polygons",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Polygon),
                oldType: "geometry",
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
                oldNullable: true);
        }
    }
}
