using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptraxDAL.Migrations
{
    /// <inheritdoc />
    public partial class ChangePlantRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Cultivars_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Cultivars");

            migrationBuilder.DropForeignKey(
                name: "FK_Species_Cultivars_CultivarID",
                schema: "Grow",
                table: "Species");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Varieties_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Varieties");

            //migrationBuilder.DropIndex(
            //    name: "IX_Varieties_CultivarID",
            //    schema: "Grow",
            //    table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Species_CultivarID",
                schema: "Grow",
                table: "Species");

            //migrationBuilder.DropIndex(
            //    name: "IX_Cultivars_CultivarID",
            //    schema: "Grow",
            //    table: "Cultivars");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Species");

            migrationBuilder.DropColumn(
                name: "CultivarID",
                schema: "Grow",
                table: "Cultivars");

            migrationBuilder.AddColumn<string>(
                name: "Phenotype",
                schema: "Grow",
                table: "Varieties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_SpeciesID",
                schema: "Grow",
                table: "Varieties",
                column: "SpeciesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Varieties_Species_SpeciesID",
                schema: "Grow",
                table: "Varieties",
                column: "SpeciesID",
                principalSchema: "Grow",
                principalTable: "Species",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Varieties_Species_SpeciesID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Varieties_SpeciesID",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "Phenotype",
                schema: "Grow",
                table: "Varieties");

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Varieties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Species",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CultivarID",
                schema: "Grow",
                table: "Cultivars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_CultivarID",
                schema: "Grow",
                table: "Varieties",
                column: "CultivarID");

            migrationBuilder.CreateIndex(
                name: "IX_Species_CultivarID",
                schema: "Grow",
                table: "Species",
                column: "CultivarID");

            migrationBuilder.CreateIndex(
                name: "IX_Cultivars_CultivarID",
                schema: "Grow",
                table: "Cultivars",
                column: "CultivarID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cultivars_Cultivars_CultivarID",
                schema: "Grow",
                table: "Cultivars",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Species_Cultivars_CultivarID",
                schema: "Grow",
                table: "Species",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Varieties_Cultivars_CultivarID",
                schema: "Grow",
                table: "Varieties",
                column: "CultivarID",
                principalSchema: "Grow",
                principalTable: "Cultivars",
                principalColumn: "ID");
        }
    }
}
