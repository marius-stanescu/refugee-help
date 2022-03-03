using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    public partial class Add_Period_property_on_Shelter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Shelter",
                type: "int",
                nullable: false,
                defaultValue: 10);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Period",
                table: "Shelter");
        }
    }
}
