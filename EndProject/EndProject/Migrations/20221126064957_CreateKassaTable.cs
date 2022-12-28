using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EndProject.Migrations
{
    public partial class CreateKassaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWages");

            migrationBuilder.CreateTable(
                name: "Kassas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balans = table.Column<float>(type: "real", nullable: false),
                    LastModifiedMoney = table.Column<float>(type: "real", nullable: false),
                    LastModified = table.Column<float>(type: "real", nullable: false),
                    LastModifiedBy = table.Column<float>(type: "real", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false,defaultValue:DateTime.UtcNow.AddHours(4))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kassas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kassas");

            migrationBuilder.CreateTable(
                name: "EmployeeWages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    WageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWages_Wages_WageId",
                        column: x => x.WageId,
                        principalTable: "Wages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWages_EmployeeId",
                table: "EmployeeWages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWages_WageId",
                table: "EmployeeWages",
                column: "WageId");
        }
    }
}
