using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class InventoryTransferAddStatusNotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Consumables_ProductID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUoM",
                table: "PlantEvents",
                newName: "WasteQuantityUOM");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentType",
                table: "PlantEvents",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<int>(
                name: "TransferID",
                table: "PlantEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PruneType",
                table: "PlantEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NewPhase",
                table: "PlantEvents",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "NewLightID",
                table: "PlantEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NewContainerID",
                table: "PlantEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ContainerTypeID",
                table: "PlantEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LightID",
                table: "PlantEvents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "InventoryTransfers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "InventoryTransfers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_ContainerTypeID",
                table: "PlantEvents",
                column: "ContainerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_LightID",
                table: "PlantEvents",
                column: "LightID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                unique: true,
                filter: "[TransferID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLocations_Name",
                table: "InventoryLocations",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Consumables_ProductID",
                table: "PlantEvents",
                column: "ProductID",
                principalTable: "Consumables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_ContainerTypes_ContainerTypeID",
                table: "PlantEvents",
                column: "ContainerTypeID",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                principalTable: "InventoryTransfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Lights_LightID",
                table: "PlantEvents",
                column: "LightID",
                principalTable: "Lights",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents",
                column: "PlantID",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Consumables_ProductID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_ContainerTypes_ContainerTypeID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Lights_LightID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_ContainerTypeID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_LightID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLocations_Name",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "ContainerTypeID",
                table: "PlantEvents");

            migrationBuilder.DropColumn(
                name: "LightID",
                table: "PlantEvents");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "InventoryTransfers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "InventoryTransfers");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUOM",
                table: "PlantEvents",
                newName: "WasteQuantityUoM");

            migrationBuilder.AlterColumn<string>(
                name: "TreatmentType",
                table: "PlantEvents",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TransferID",
                table: "PlantEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PruneType",
                table: "PlantEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NewPhase",
                table: "PlantEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewLightID",
                table: "PlantEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NewContainerID",
                table: "PlantEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Consumables_ProductID",
                table: "PlantEvents",
                column: "ProductID",
                principalTable: "Consumables",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                principalTable: "InventoryTransfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents",
                column: "PlantID",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
