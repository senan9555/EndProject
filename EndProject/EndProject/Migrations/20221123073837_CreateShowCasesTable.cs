using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class CreateShowCasesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShowCaseId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShowCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCases", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ShowCaseId",
                table: "Categories",
                column: "ShowCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_ShowCases_ShowCaseId",
                table: "Categories",
                column: "ShowCaseId",
                principalTable: "ShowCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShowCases_ShowCaseId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "ShowCases");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShowCaseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShowCaseId",
                table: "Categories");
        }
    }
}
