using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrowFlowMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Grow");

            migrationBuilder.CreateTable(
                name: "Containers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacity = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    CapacityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Containers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Strains",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StrainType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strains", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    LocationID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StrainRelationships",
                schema: "Grow",
                columns: table => new
                {
                    ParentID = table.Column<int>(type: "int", nullable: false),
                    ChildID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrainRelationships", x => new { x.ParentID, x.ChildID });
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ChildID",
                        column: x => x.ChildID,
                        principalSchema: "Grow",
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StrainRelationships_Strains_ParentID",
                        column: x => x.ParentID,
                        principalSchema: "Grow",
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lights",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PPF = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    PPFD = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    BulbType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorSpectrum = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoverageArea = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: true),
                    LifespanHours = table.Column<int>(type: "int", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Voltage = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lights", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lights_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalSchema: "Grow",
                        principalTable: "Rooms",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Plants",
                schema: "Grow",
                columns: table => new
                {
                    PlantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrainID = table.Column<int>(type: "int", nullable: false),
                    GrowthPhase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    LightID = table.Column<int>(type: "int", nullable: true),
                    ContainerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.PlantID);
                    table.ForeignKey(
                        name: "FK_Plants_Containers_ContainerID",
                        column: x => x.ContainerID,
                        principalTable: "Containers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Lights_LightID",
                        column: x => x.LightID,
                        principalSchema: "Grow",
                        principalTable: "Lights",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalSchema: "Grow",
                        principalTable: "Rooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Plants_Strains_StrainID",
                        column: x => x.StrainID,
                        principalSchema: "Grow",
                        principalTable: "Strains",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantTransfers",
                schema: "Grow",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantID = table.Column<int>(type: "int", nullable: false),
                    TransferType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    OriginID = table.Column<int>(type: "int", nullable: false),
                    DestinationID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTransfers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Containers_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Containers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Containers_OriginID",
                        column: x => x.OriginID,
                        principalTable: "Containers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Plants_PlantID",
                        column: x => x.PlantID,
                        principalSchema: "Grow",
                        principalTable: "Plants",
                        principalColumn: "PlantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Rooms_DestinationID",
                        column: x => x.DestinationID,
                        principalSchema: "Grow",
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlantTransfers_Rooms_OriginID",
                        column: x => x.OriginID,
                        principalSchema: "Grow",
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lights_RoomID",
                schema: "Grow",
                table: "Lights",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_ContainerID",
                schema: "Grow",
                table: "Plants",
                column: "ContainerID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_LightID",
                schema: "Grow",
                table: "Plants",
                column: "LightID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_RoomID",
                schema: "Grow",
                table: "Plants",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Plants_StrainID",
                schema: "Grow",
                table: "Plants",
                column: "StrainID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_DestinationID",
                schema: "Grow",
                table: "PlantTransfers",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_OriginID",
                schema: "Grow",
                table: "PlantTransfers",
                column: "OriginID");

            migrationBuilder.CreateIndex(
                name: "IX_PlantTransfers_PlantID",
                schema: "Grow",
                table: "PlantTransfers",
                column: "PlantID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_LocationID",
                schema: "Grow",
                table: "Rooms",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_StrainRelationships_ChildID",
                schema: "Grow",
                table: "StrainRelationships",
                column: "ChildID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantTransfers",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "StrainRelationships",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Plants",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Containers");

            migrationBuilder.DropTable(
                name: "Lights",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Strains",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
