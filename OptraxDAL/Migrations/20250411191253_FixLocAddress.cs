using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class FixLocAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Locations_SiteId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Address_AddressId1",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_AddressId",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Address_SiteId",
                schema: "Admin",
                table: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId1",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_AddressId");

            migrationBuilder.AlterColumn<string>(
                name: "LocationType",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Locations_AddressId",
                schema: "Admin",
                table: "Locations",
                newName: "IX_Locations_AddressId1");

            migrationBuilder.AlterColumn<string>(
                name: "LocationType",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

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
                name: "FK_Locations_Address_AddressId1",
                schema: "Admin",
                table: "Locations",
                column: "AddressId",
                principalSchema: "Admin",
                principalTable: "Address",
                principalColumn: "Id");
        }
    }
}
