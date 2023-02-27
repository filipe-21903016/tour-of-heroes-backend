using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOfHeroes.Migrations
{
    /// <inheritdoc />
    public partial class heroCountryIdToHeroCountry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Heroes_CountryId",
                table: "Heroes",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Countries_CountryId",
                table: "Heroes",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Countries_CountryId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_CountryId",
                table: "Heroes");
        }
    }
}
