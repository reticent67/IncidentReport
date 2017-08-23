using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentReport.Migrations
{
    public partial class UpdateLocations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "StreetType",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Suffix",
                table: "Locations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetType",
                table: "Locations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Suffix",
                table: "Locations",
                nullable: true);
        }
    }
}
