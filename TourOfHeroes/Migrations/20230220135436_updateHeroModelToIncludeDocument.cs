using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOfHeroes.Migrations
{
    /// <inheritdoc />
    public partial class updateHeroModelToIncludeDocument : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Heroes_HeroId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_HeroId",
                table: "Documents");

            migrationBuilder.AddColumn<int>(
                name: "DocumentId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentId1",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_DocumentId1",
                table: "Heroes",
                column: "DocumentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Documents_DocumentId1",
                table: "Heroes",
                column: "DocumentId1",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Documents_DocumentId1",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_DocumentId1",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "DocumentId1",
                table: "Heroes");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_HeroId",
                table: "Documents",
                column: "HeroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Heroes_HeroId",
                table: "Documents",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
