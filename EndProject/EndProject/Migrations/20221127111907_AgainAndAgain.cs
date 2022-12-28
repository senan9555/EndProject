using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class AgainAndAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Wages");

            migrationBuilder.AddColumn<float>(
                name: "Money",
                table: "Wages",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Wages");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Wages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
