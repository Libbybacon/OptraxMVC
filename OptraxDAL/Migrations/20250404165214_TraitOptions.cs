using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class TraitOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ProfileId",
            //    schema: "Grow",
            //    table: "PlantTraits");

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsDropdown",
            //    schema: "Grow",
            //    table: "TraitDefinitions",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsMultiSelect",
            //    schema: "Grow",
            //    table: "TraitDefinitions",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AddColumn<bool>(
            //    name: "IsRange",
            //    schema: "Grow",
            //    table: "TraitDefinitions",
            //    type: "bit",
            //    nullable: false,
            //    defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TraitOptions",
                schema: "Grow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefinitionId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateLastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TraitOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TraitOptions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TraitOptions_TraitDefinitions_DefinitionId",
                        column: x => x.DefinitionId,
                        principalSchema: "Grow",
                        principalTable: "TraitDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantTraitTraitOption",
                schema: "Grow",
                columns: table => new
                {
                    SelectedOptionsId = table.Column<int>(type: "int", nullable: false),
                    TraitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantTraitTraitOption", x => new { x.SelectedOptionsId, x.TraitsId });
                    table.ForeignKey(
                        name: "FK_PlantTraitTraitOption_PlantTraits_TraitsId",
                        column: x => x.TraitsId,
                        principalSchema: "Grow",
                        principalTable: "PlantTraits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlantTraitTraitOption_TraitOptions_SelectedOptionsId",
                        column: x => x.SelectedOptionsId,
                        principalSchema: "Grow",
                        principalTable: "TraitOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlantTraitTraitOption_TraitsId",
                schema: "Grow",
                table: "PlantTraitTraitOption",
                column: "TraitsId");

            migrationBuilder.CreateIndex(
                name: "IX_TraitOptions_DefinitionId",
                schema: "Grow",
                table: "TraitOptions",
                column: "DefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_TraitOptions_UserId",
                schema: "Grow",
                table: "TraitOptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlantTraitTraitOption",
                schema: "Grow");

            migrationBuilder.DropTable(
                name: "TraitOptions",
                schema: "Grow");

            migrationBuilder.DropColumn(
                name: "IsDropdown",
                schema: "Grow",
                table: "TraitDefinitions");

            migrationBuilder.DropColumn(
                name: "IsMultiSelect",
                schema: "Grow",
                table: "TraitDefinitions");

            migrationBuilder.DropColumn(
                name: "IsRange",
                schema: "Grow",
                table: "TraitDefinitions");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                schema: "Grow",
                table: "PlantTraits",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
