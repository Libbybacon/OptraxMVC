using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddMapObjectPoints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Points_Lines_MapLineID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropForeignKey(
                name: "FK_Points_Polygons_MapPolygonID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_MapLineID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropIndex(
                name: "IX_Points_MapPolygonID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "MapLineID",
                schema: "Map",
                table: "Points");

            migrationBuilder.DropColumn(
                name: "MapPolygonID",
                schema: "Map",
                table: "Points");

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FillColor",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BorderColor",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Elevation",
                schema: "Map",
                table: "Points",
                type: "decimal(12,8)",
                precision: 12,
                scale: 8,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "MapObjectPoints",
                schema: "Map",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MapObjectID = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: false),
                    Elevation = table.Column<decimal>(type: "decimal(12,8)", precision: 12, scale: 8, nullable: true),
                    MapLineID = table.Column<int>(type: "int", nullable: true),
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MapObjectPoints",
                schema: "Map");

            migrationBuilder.DropColumn(
                name: "Elevation",
                schema: "Map",
                table: "Points");

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "FillColor",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "BorderColor",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AddColumn<int>(
                name: "MapLineID",
                schema: "Map",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MapPolygonID",
                schema: "Map",
                table: "Points",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)",
                oldMaxLength: 9);

            migrationBuilder.CreateIndex(
                name: "IX_Points_MapLineID",
                schema: "Map",
                table: "Points",
                column: "MapLineID");

            migrationBuilder.CreateIndex(
                name: "IX_Points_MapPolygonID",
                schema: "Map",
                table: "Points",
                column: "MapPolygonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Lines_MapLineID",
                schema: "Map",
                table: "Points",
                column: "MapLineID",
                principalSchema: "Map",
                principalTable: "Lines",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Points_Polygons_MapPolygonID",
                schema: "Map",
                table: "Points",
                column: "MapPolygonID",
                principalSchema: "Map",
                principalTable: "Polygons",
                principalColumn: "ID");
        }
    }
}
