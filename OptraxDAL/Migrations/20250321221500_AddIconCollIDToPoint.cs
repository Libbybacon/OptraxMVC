using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddIconCollIDToPoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IconCollectionID",
                schema: "Map",
                table: "Points",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<LineString>(
                name: "LineGeometry",
                schema: "Map",
                table: "Lines",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(LineString),
                oldType: "geometry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconCollectionID",
                schema: "Map",
                table: "Points");

            migrationBuilder.AlterColumn<LineString>(
                name: "LineGeometry",
                schema: "Map",
                table: "Lines",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(LineString),
                oldType: "geometry",
                oldNullable: true);
        }
    }
}
