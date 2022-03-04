using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    public partial class Add_CreatedOnUtc_and_DeactivatedOnUtc_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Transport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedOnUtc",
                table: "Transport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnUtc",
                table: "Shelter",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeactivatedOnUtc",
                table: "Shelter",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "DeactivatedOnUtc",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "CreatedOnUtc",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "DeactivatedOnUtc",
                table: "Shelter");
        }
    }
}
