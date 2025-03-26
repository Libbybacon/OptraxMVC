using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMapCircle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapObjectPoints",
                schema: "Map");

            migrationBuilder.CreateTable(
                name: "Circles",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Radius = table.Column<double>(type: "float(12)", precision: 12, scale: 8, nullable: false),
                    Area = table.Column<Polygon>(
    type: "geometry",
    nullable: true,
    computedColumnSql: "geometry::Point([Latitude], [Longitude], 4326).STBuffer([Radius])",
    stored: true),
                    BorderWidth = table.Column<int>(type: "int", nullable: false),
                    BorderColor = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    FillColor = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    DashArray = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Circles_MapObjects_ID",
                        column: x => x.ID,
                        principalSchema: "Map",
                        principalTable: "MapObjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Circles",
                schema: "Map");

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

            migrationBuilder.CreateTable(
                name: "MapObjectPoints",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Elevation = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: false),
                    MapLineID = table.Column<int>(type: "int", nullable: true),
                    MapObjectID = table.Column<int>(type: "int", nullable: false),
                    MapPolygonID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MapObjectPoints", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MapObjectPoints_Lines_MapLineID",
                        column: x => x.MapLineID,
                        principalSchema: "Map",
                        principalTable: "Lines",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_MapObjectPoints_Polygons_MapPolygonID",
                        column: x => x.MapPolygonID,
                        principalSchema: "Map",
                        principalTable: "Polygons",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MapObjectPoints_MapLineID",
                schema: "Map",
                table: "MapObjectPoints",
                column: "MapLineID");

            migrationBuilder.CreateIndex(
                name: "IX_MapObjectPoints_MapPolygonID",
                schema: "Map",
                table: "MapObjectPoints",
                column: "MapPolygonID");
        }
    }
}
