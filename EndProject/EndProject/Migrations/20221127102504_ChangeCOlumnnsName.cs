using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class ChangeCOlumnnsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Incomes",
                newName: "For");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Expenses",
                newName: "For");

            migrationBuilder.AddColumn<float>(
                name: "Money",
                table: "Incomes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Money",
                table: "Expenses",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Incomes");

            migrationBuilder.DropColumn(
                name: "Money",
                table: "Expenses");

            migrationBuilder.RenameColumn(
                name: "For",
                table: "Incomes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "For",
                table: "Expenses",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Incomes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
