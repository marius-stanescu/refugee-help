using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Api.Migrations
{
    public partial class Add_Transport_and_Shelter_entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_RegionId = table.Column<int>(type: "int", nullable: true),
                    Address_CityId = table.Column<int>(type: "int", nullable: true),
                    AdultCapacity = table.Column<int>(type: "int", nullable: false),
                    ChildrenCapacity = table.Column<int>(type: "int", nullable: false),
                    AllowsPets = table.Column<bool>(type: "bit", nullable: false),
                    MaxPeriodInDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shelter_City_Address_CityId",
                        column: x => x.Address_CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Shelter_Region_Address_RegionId",
                        column: x => x.Address_RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingPoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination_RegionId = table.Column<int>(type: "int", nullable: true),
                    Destination_CityId = table.Column<int>(type: "int", nullable: true),
                    AdultSeats = table.Column<int>(type: "int", nullable: false),
                    ChildSeats = table.Column<int>(type: "int", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transport_City_Destination_CityId",
                        column: x => x.Destination_CityId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transport_Region_Destination_RegionId",
                        column: x => x.Destination_RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_Address_CityId",
                table: "Shelter",
                column: "Address_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_Address_RegionId",
                table: "Shelter",
                column: "Address_RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transport_Destination_CityId",
                table: "Transport",
                column: "Destination_CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transport_Destination_RegionId",
                table: "Transport",
                column: "Destination_RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelter");

            migrationBuilder.DropTable(
                name: "Transport");
        }
    }
}
