using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectMDS.Migrations
{
    public partial class DatabaseModifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataPlecare",
                table: "Cazari");

            migrationBuilder.DropColumn(
                name: "DataSosire",
                table: "Cazari");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVizita",
                table: "TicheteMasa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPlecare",
                table: "RezervariCazari",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSosire",
                table: "RezervariCazari",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataVizita",
                table: "Bilete",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVizita",
                table: "TicheteMasa");

            migrationBuilder.DropColumn(
                name: "DataPlecare",
                table: "RezervariCazari");

            migrationBuilder.DropColumn(
                name: "DataSosire",
                table: "RezervariCazari");

            migrationBuilder.DropColumn(
                name: "DataVizita",
                table: "Bilete");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataPlecare",
                table: "Cazari",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSosire",
                table: "Cazari",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
