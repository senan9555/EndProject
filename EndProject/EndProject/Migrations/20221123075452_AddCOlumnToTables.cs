using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class AddCOlumnToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_ShowCases_ShowCaseId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ShowCaseId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ShowCaseId",
                table: "Categories");

            migrationBuilder.CreateTable(
                name: "ShowCaseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ShowCaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowCaseCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowCaseCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowCaseCategory_ShowCases_ShowCaseId",
                        column: x => x.ShowCaseId,
                        principalTable: "ShowCases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShowCaseCategory_CategoryId",
                table: "ShowCaseCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowCaseCategory_ShowCaseId",
                table: "ShowCaseCategory",
                column: "ShowCaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowCaseCategory");

            migrationBuilder.AddColumn<int>(
                name: "ShowCaseId",
                table: "Categories",
                type: "int",
                nullable: true);

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
    }
}
