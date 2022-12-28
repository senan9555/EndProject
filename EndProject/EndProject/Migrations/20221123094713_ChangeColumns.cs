using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class ChangeColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShowCaseCategory");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ShowCases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShowCases_CategoryId",
                table: "ShowCases",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShowCases_Categories_CategoryId",
                table: "ShowCases",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShowCases_Categories_CategoryId",
                table: "ShowCases");

            migrationBuilder.DropIndex(
                name: "IX_ShowCases_CategoryId",
                table: "ShowCases");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ShowCases");

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
    }
}
