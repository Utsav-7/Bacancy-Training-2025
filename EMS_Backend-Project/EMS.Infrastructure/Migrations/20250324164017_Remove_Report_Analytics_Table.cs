using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Backend_Project.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Report_Analytics_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportAnalyses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReportAnalyses",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    AverageDailyHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    ConsistencyTime = table.Column<double>(type: "float", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTaken = table.Column<int>(type: "int", nullable: false),
                    PerformanceRating = table.Column<double>(type: "float", nullable: false),
                    ReportDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TotalWorkedHours = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportAnalyses", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_ReportAnalyses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId");
                    table.ForeignKey(
                        name: "FK_ReportAnalyses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalyses_DepartmentId",
                table: "ReportAnalyses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportAnalyses_EmployeeId",
                table: "ReportAnalyses",
                column: "EmployeeId");
        }
    }
}
