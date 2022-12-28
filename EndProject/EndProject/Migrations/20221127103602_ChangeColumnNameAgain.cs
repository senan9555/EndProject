using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class ChangeColumnNameAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Incomes",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "CreateTime",
                table: "Expenses",
                newName: "StartTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Incomes",
                newName: "CreateTime");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Expenses",
                newName: "CreateTime");
        }
    }
}
