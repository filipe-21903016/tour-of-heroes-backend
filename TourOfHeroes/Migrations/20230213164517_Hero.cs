using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourOfHeroes.Migrations
{
    /// <inheritdoc />
    public partial class Hero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Heroes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PeopleSaved",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "PeopleSaved",
                table: "Heroes");
        }
    }
}
