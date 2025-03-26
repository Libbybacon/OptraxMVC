using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddColorRgbaStruct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropColumn(
                name: "FillColor",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "Map",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "Color",
                schema: "Map",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "FillColor",
                schema: "Map",
                table: "Circles");

            migrationBuilder.AddColumn<byte[]>(
                name: "ColorBytes",
                schema: "Map",
                table: "Polygons",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "FillColorBytes",
                schema: "Map",
                table: "Polygons",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ColorBytes",
                schema: "Map",
                table: "Lines",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "FillColorBytes",
                schema: "Map",
                table: "Lines",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "ColorBytes",
                schema: "Map",
                table: "Circles",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "FillColorBytes",
                schema: "Map",
                table: "Circles",
                type: "varbinary(4)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorBytes",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropColumn(
                name: "FillColorBytes",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropColumn(
                name: "ColorBytes",
                schema: "Map",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "FillColorBytes",
                schema: "Map",
                table: "Lines");

            migrationBuilder.DropColumn(
                name: "ColorBytes",
                schema: "Map",
                table: "Circles");

            migrationBuilder.DropColumn(
                name: "FillColorBytes",
                schema: "Map",
                table: "Circles");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FillColor",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                schema: "Map",
                table: "Circles",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FillColor",
                schema: "Map",
                table: "Circles",
                type: "nvarchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "");
        }
    }
}
