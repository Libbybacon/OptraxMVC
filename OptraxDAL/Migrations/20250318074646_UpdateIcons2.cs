using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIcons2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageFilePath",
                schema: "Map",
                table: "Icons",
                newName: "ImagePath");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Map",
                table: "MapObjects",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                schema: "Map",
                table: "Icons",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "Active",
                schema: "Map",
                table: "Icons");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                schema: "Map",
                table: "Icons",
                newName: "ImageFilePath");
        }
    }
}
