using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocation_LocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocation_Addresses_AddressID",
                table: "InventoryLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocation_ContainerTypes_ContainerTypeID",
                table: "InventoryLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocation_InventoryLocation_ParentID",
                table: "InventoryLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocationStockItem_InventoryLocation_LocationsID",
                table: "InventoryLocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_AprrovingManagerId",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocation_DestinationID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocation_OriginID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_AspNetUsers_EmployeeId",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_InventoryLocation_InventoryLocationID",
                table: "ProductItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UOMs",
                table: "UOMs");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_EmployeeId",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTransfers_AprrovingManagerId",
                table: "InventoryTransfers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLocation",
                table: "InventoryLocation");

            migrationBuilder.DropColumn(
                name: "ProductUnitUOM",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PlantEvents");

            migrationBuilder.DropColumn(
                name: "AprrovingManagerId",
                table: "InventoryTransfers");

            migrationBuilder.DropColumn(
                name: "CapacityUOM",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "UnitUOM",
                table: "Consumables");

            migrationBuilder.RenameTable(
                name: "UOMs",
                newName: "UoMs");

            migrationBuilder.RenameTable(
                name: "InventoryLocation",
                newName: "InventoryLocations");

            migrationBuilder.RenameColumn(
                name: "StartPhase",
                table: "Plants",
                newName: "Phase");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUOM",
                table: "PlantEvents",
                newName: "WasteQuantityUoM");

            migrationBuilder.RenameColumn(
                name: "QuantityUOM",
                table: "PlantEvents",
                newName: "QuantityUoM");

            migrationBuilder.RenameColumn(
                name: "UnitUOM",
                table: "InventoryTransfers",
                newName: "UnitUoM");

            migrationBuilder.RenameColumn(
                name: "DefaultUOM",
                table: "InventoryItems",
                newName: "DefaultUoM");

            migrationBuilder.RenameColumn(
                name: "MaintenanceInvervalUOM",
                table: "DurableItems",
                newName: "MaintenanceInvervalUoM");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUOM",
                table: "Crops",
                newName: "WasteQuantityUoM");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocation_ParentID",
                table: "InventoryLocations",
                newName: "IX_InventoryLocations_ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocation_ContainerTypeID",
                table: "InventoryLocations",
                newName: "IX_InventoryLocations_ContainerTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocation_AddressID",
                table: "InventoryLocations",
                newName: "IX_InventoryLocations_AddressID");

            migrationBuilder.AlterColumn<string>(
                name: "UnitAbbr",
                table: "UoMs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UoMs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "UoMs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnitName",
                table: "UoMs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "UnitUoMName",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "PlantEvents",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UnitUoM",
                table: "InventoryTransfers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "ApprovingManagerID",
                table: "InventoryTransfers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "InventoryTransfers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StockUoM",
                table: "InventoryItems",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crops",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UoMName",
                table: "ContainerTypes",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UoMName",
                table: "Consumables",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BusinessType",
                table: "Businesses",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UoMs",
                table: "UoMs",
                column: "UnitName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLocations",
                table: "InventoryLocations",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Strains_Name",
                table: "Strains",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductName",
                table: "Products",
                column: "ProductName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitUoMName",
                table: "Products",
                column: "UnitUoMName");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_UserID",
                table: "PlantEvents",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_ApprovingManagerID",
                table: "InventoryTransfers",
                column: "ApprovingManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_UserID",
                table: "InventoryTransfers",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_BatchID",
                table: "Crops",
                column: "BatchID",
                unique: true,
                filter: "[BatchID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_Name",
                table: "Crops",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ContainerTypes_UoMName",
                table: "ContainerTypes",
                column: "UoMName");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_UoMName",
                table: "Consumables",
                column: "UoMName");

            migrationBuilder.CreateIndex(
                name: "IX_Businesses_Name",
                table: "Businesses",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_UoMs_UoMName",
                table: "Consumables",
                column: "UoMName",
                principalTable: "UoMs",
                principalColumn: "UnitName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContainerTypes_UoMs_UoMName",
                table: "ContainerTypes",
                column: "UoMName",
                principalTable: "UoMs",
                principalColumn: "UnitName",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocations_LocationID",
                table: "Crops",
                column: "LocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_Addresses_AddressID",
                table: "InventoryLocations",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_ContainerTypes_ContainerTypeID",
                table: "InventoryLocations",
                column: "ContainerTypeID",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocations_InventoryLocations_ParentID",
                table: "InventoryLocations",
                column: "ParentID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocationStockItem_InventoryLocations_LocationsID",
                table: "InventoryLocationStockItem",
                column: "LocationsID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_ApprovingManagerID",
                table: "InventoryTransfers",
                column: "ApprovingManagerID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_UserID",
                table: "InventoryTransfers",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_DestinationID",
                table: "InventoryTransfers",
                column: "DestinationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_OriginID",
                table: "InventoryTransfers",
                column: "OriginID",
                principalTable: "InventoryLocations",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_AspNetUsers_UserID",
                table: "PlantEvents",
                column: "UserID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_InventoryLocations_InventoryLocationID",
                table: "ProductItems",
                column: "InventoryLocationID",
                principalTable: "InventoryLocations",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UoMs_UnitUoMName",
                table: "Products",
                column: "UnitUoMName",
                principalTable: "UoMs",
                principalColumn: "UnitName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_UoMs_UoMName",
                table: "Consumables");

            migrationBuilder.DropForeignKey(
                name: "FK_ContainerTypes_UoMs_UoMName",
                table: "ContainerTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Crops_InventoryLocations_LocationID",
                table: "Crops");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_Addresses_AddressID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_ContainerTypes_ContainerTypeID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocations_InventoryLocations_ParentID",
                table: "InventoryLocations");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLocationStockItem_InventoryLocations_LocationsID",
                table: "InventoryLocationStockItem");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_ApprovingManagerID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_UserID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_DestinationID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_InventoryLocations_OriginID",
                table: "InventoryTransfers");

            migrationBuilder.DropForeignKey(
                name: "FK_PlantEvents_AspNetUsers_UserID",
                table: "PlantEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_InventoryLocations_InventoryLocationID",
                table: "ProductItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_UoMs_UnitUoMName",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UoMs",
                table: "UoMs");

            migrationBuilder.DropIndex(
                name: "IX_Strains_Name",
                table: "Strains");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UnitUoMName",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_PlantEvents_UserID",
                table: "PlantEvents");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTransfers_ApprovingManagerID",
                table: "InventoryTransfers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTransfers_UserID",
                table: "InventoryTransfers");

            migrationBuilder.DropIndex(
                name: "IX_Crops_BatchID",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_Name",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_ContainerTypes_UoMName",
                table: "ContainerTypes");

            migrationBuilder.DropIndex(
                name: "IX_Consumables_UoMName",
                table: "Consumables");

            migrationBuilder.DropIndex(
                name: "IX_Businesses_Name",
                table: "Businesses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLocations",
                table: "InventoryLocations");

            migrationBuilder.DropColumn(
                name: "UnitUoMName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "InventoryTransfers");

            migrationBuilder.DropColumn(
                name: "StockUoM",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "UoMName",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "UoMName",
                table: "Consumables");

            migrationBuilder.DropColumn(
                name: "BusinessType",
                table: "Businesses");

            migrationBuilder.RenameTable(
                name: "UoMs",
                newName: "UOMs");

            migrationBuilder.RenameTable(
                name: "InventoryLocations",
                newName: "InventoryLocation");

            migrationBuilder.RenameColumn(
                name: "Phase",
                table: "Plants",
                newName: "StartPhase");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUoM",
                table: "PlantEvents",
                newName: "WasteQuantityUOM");

            migrationBuilder.RenameColumn(
                name: "QuantityUoM",
                table: "PlantEvents",
                newName: "QuantityUOM");

            migrationBuilder.RenameColumn(
                name: "UnitUoM",
                table: "InventoryTransfers",
                newName: "UnitUOM");

            migrationBuilder.RenameColumn(
                name: "DefaultUoM",
                table: "InventoryItems",
                newName: "DefaultUOM");

            migrationBuilder.RenameColumn(
                name: "MaintenanceInvervalUoM",
                table: "DurableItems",
                newName: "MaintenanceInvervalUOM");

            migrationBuilder.RenameColumn(
                name: "WasteQuantityUoM",
                table: "Crops",
                newName: "WasteQuantityUOM");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocations_ParentID",
                table: "InventoryLocation",
                newName: "IX_InventoryLocation_ParentID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocations_ContainerTypeID",
                table: "InventoryLocation",
                newName: "IX_InventoryLocation_ContainerTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLocations_AddressID",
                table: "InventoryLocation",
                newName: "IX_InventoryLocation_AddressID");

            migrationBuilder.AlterColumn<string>(
                name: "UnitAbbr",
                table: "UOMs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "UOMs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "UOMs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UnitName",
                table: "UOMs",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ProductName",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductUnitUOM",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserID",
                table: "PlantEvents",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "PlantEvents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UnitUOM",
                table: "InventoryTransfers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ApprovingManagerID",
                table: "InventoryTransfers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AprrovingManagerId",
                table: "InventoryTransfers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CapacityUOM",
                table: "ContainerTypes",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitUOM",
                table: "Consumables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Addresses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UOMs",
                table: "UOMs",
                column: "UnitName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLocation",
                table: "InventoryLocation",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantEvents_EmployeeId",
                table: "PlantEvents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_AprrovingManagerId",
                table: "InventoryTransfers",
                column: "AprrovingManagerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_InventoryLocation_LocationID",
                table: "Crops",
                column: "LocationID",
                principalTable: "InventoryLocation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocation_Addresses_AddressID",
                table: "InventoryLocation",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocation_ContainerTypes_ContainerTypeID",
                table: "InventoryLocation",
                column: "ContainerTypeID",
                principalTable: "ContainerTypes",
                principalColumn: "ContainerTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocation_InventoryLocation_ParentID",
                table: "InventoryLocation",
                column: "ParentID",
                principalTable: "InventoryLocation",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLocationStockItem_InventoryLocation_LocationsID",
                table: "InventoryLocationStockItem",
                column: "LocationsID",
                principalTable: "InventoryLocation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_AprrovingManagerId",
                table: "InventoryTransfers",
                column: "AprrovingManagerId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocation_DestinationID",
                table: "InventoryTransfers",
                column: "DestinationID",
                principalTable: "InventoryLocation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_InventoryLocation_OriginID",
                table: "InventoryTransfers",
                column: "OriginID",
                principalTable: "InventoryLocation",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlantEvents_AspNetUsers_EmployeeId",
                table: "PlantEvents",
                column: "EmployeeId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_InventoryLocation_InventoryLocationID",
                table: "ProductItems",
                column: "InventoryLocationID",
                principalTable: "InventoryLocation",
                principalColumn: "ID");
        }
    }
}
