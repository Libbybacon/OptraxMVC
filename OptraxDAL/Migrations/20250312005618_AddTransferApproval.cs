using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTransferApproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_ApprovingManagerID",
                table: "InventoryTransfers");

            migrationBuilder.DropIndex(
                name: "IX_InventoryTransfers_ApprovingManagerID",
                table: "InventoryTransfers");

            migrationBuilder.DropColumn(
                name: "ApprovingManagerID",
                table: "InventoryTransfers");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalID",
                table: "InventoryTransfers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Date",
                table: "InventoryTransfers",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.CreateTable(
                name: "TransferApprovals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferID = table.Column<int>(type: "int", nullable: false),
                    ApprovalDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferApprovals", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TransferApprovals_AspNetUsers_ManagerID",
                        column: x => x.ManagerID,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TransferApprovals_InventoryTransfers_TransferID",
                        column: x => x.TransferID,
                        principalTable: "InventoryTransfers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TransferApprovals_ManagerID",
                table: "TransferApprovals",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_TransferApprovals_TransferID",
                table: "TransferApprovals",
                column: "TransferID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransferApprovals");

            migrationBuilder.DropColumn(
                name: "ApprovalID",
                table: "InventoryTransfers");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "InventoryTransfers");

            migrationBuilder.AddColumn<string>(
                name: "ApprovingManagerID",
                table: "InventoryTransfers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransfers_ApprovingManagerID",
                table: "InventoryTransfers",
                column: "ApprovingManagerID");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryTransfers_AspNetUsers_ApprovingManagerID",
                table: "InventoryTransfers",
                column: "ApprovingManagerID",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
