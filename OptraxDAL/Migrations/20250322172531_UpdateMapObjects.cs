using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMapObjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BorderWidth",
                schema: "Map",
                table: "Polygons",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "BorderColor",
                schema: "Map",
                table: "Polygons",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "BorderWidth",
                schema: "Map",
                table: "Circles",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "BorderColor",
                schema: "Map",
                table: "Circles",
                newName: "Color");

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<string>(
                name: "DashArray",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "DashArray",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Circles",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DashArray",
                schema: "Map",
                table: "Polygons");

            migrationBuilder.DropColumn(
                name: "Pattern",
                schema: "Map",
                table: "Circles");

            migrationBuilder.RenameColumn(
                name: "Weight",
                schema: "Map",
                table: "Polygons",
                newName: "BorderWidth");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "Map",
                table: "Polygons",
                newName: "BorderColor");

            migrationBuilder.RenameColumn(
                name: "Weight",
                schema: "Map",
                table: "Circles",
                newName: "BorderWidth");

            migrationBuilder.RenameColumn(
                name: "Color",
                schema: "Map",
                table: "Circles",
                newName: "BorderColor");

            migrationBuilder.AlterColumn<string>(
                name: "Pattern",
                schema: "Map",
                table: "Polygons",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "DashArray",
                schema: "Map",
                table: "Lines",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);
        }
    }
}
