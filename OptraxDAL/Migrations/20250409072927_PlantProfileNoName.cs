using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantProfileNoName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantProfiles_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropIndex(
                name: "IX_PlantProfiles_UserId",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropColumn(
                name: "DateLastModified",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropColumn(
                name: "Details",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Grow",
                table: "PlantProfiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "Grow",
                table: "PlantProfiles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "PlantProfiles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateLastModified",
                schema: "Grow",
                table: "PlantProfiles",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Details",
                schema: "Grow",
                table: "PlantProfiles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Grow",
                table: "PlantProfiles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                schema: "Grow",
                table: "PlantProfiles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantProfiles_UserId",
                schema: "Grow",
                table: "PlantProfiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantProfiles_AspNetUsers_UserId",
                schema: "Grow",
                table: "PlantProfiles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
