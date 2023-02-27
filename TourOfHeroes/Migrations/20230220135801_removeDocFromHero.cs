using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOfHeroes.Migrations
{
    /// <inheritdoc />
    public partial class removeDocFromHero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
