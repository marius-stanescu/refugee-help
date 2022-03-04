using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    public partial class Add_IsActive_and_DeactivatioReason_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeactivationReason",
                table: "Transport",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Transport",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DeactivationReason",
                table: "Shelter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Shelter",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeactivationReason",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Transport");

            migrationBuilder.DropColumn(
                name: "DeactivationReason",
                table: "Shelter");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Shelter");
        }
    }
}
