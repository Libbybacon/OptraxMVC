﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class PlantEventsOneClass : Migration
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
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents");

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

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                unique: true,
                filter: "[TransferID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Consumables_ProductID",
                table: "PlantEvents",
                column: "ProductID",
                principalTable: "Consumables",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_InventoryTransfers_TransferID",
                table: "PlantEvents",
                column: "TransferID",
                principalTable: "InventoryTransfers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_Plants_PlantID",
                table: "PlantEvents",
                column: "PlantID",
                principalTable: "Plants",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
