using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrackingBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedByID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Varieties",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "UoMs",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Strains",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Inventory",
                table: "StockItems",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Species",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Inventory",
                table: "Resources",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Products",
                table: "Products",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Products",
                table: "ProductItems",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Products",
                table: "ProductBatches",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Map",
                table: "MapObjects",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "Locations",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "Inputs",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Cultivars",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Crops",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "ContainerTypes",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Inventory",
                table: "Categories",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "Businesses",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Grow",
                table: "Batches",
                newName: "LastModifiedUserID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedByID",
                schema: "Admin",
                table: "Address",
                newName: "LastModifiedUserID");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Varieties",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Strains",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "StockItems",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Species",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "SalesOrders",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Resources",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "Products",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "ProductBatches",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Map",
                table: "MapObjects",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Locations",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Inputs",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Inputs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Cultivars",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Crops",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Categories",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Businesses",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Batches",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Address",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AddColumn<string>(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "UoMs");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Strains");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "StockItems");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Products",
                table: "ProductBatches");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Map",
                table: "MapObjects");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Inputs");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "ContainerTypes");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Inventory",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Businesses");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Grow",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "CreatedUserID",
                schema: "Admin",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Varieties",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "UoMs",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Strains",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "StockItems",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Species",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "SalesOrders",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Resources",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "Products",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductItems",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Products",
                table: "ProductBatches",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Map",
                table: "MapObjects",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Locations",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Inputs",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Cultivars",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Crops",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "ContainerTypes",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Inventory",
                table: "Categories",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Businesses",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Grow",
                table: "Batches",
                newName: "LastModifiedByID");

            migrationBuilder.RenameColumn(
                name: "LastModifiedUserID",
                schema: "Admin",
                table: "Address",
                newName: "LastModifiedByID");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Varieties",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "UoMs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "UoMs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Strains",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Strains",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "StockItems",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Inventory",
                table: "StockItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Species",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Species",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "SalesOrders",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Inventory",
                table: "SalesOrders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Resources",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Inventory",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "Products",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Products",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "ProductItems",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Products",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Products",
                table: "ProductBatches",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Products",
                table: "ProductBatches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Map",
                table: "MapObjects",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Map",
                table: "MapObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Locations",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Inputs",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "Inputs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Cultivars",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Cultivars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Crops",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Crops",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "ContainerTypes",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "ContainerTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Inventory",
                table: "Categories",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Inventory",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Businesses",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "Businesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Grow",
                table: "Batches",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Grow",
                table: "Batches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateCreated",
                schema: "Admin",
                table: "Address",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByID",
                schema: "Admin",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
