using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Backend_Project.Migrations
{
    /// <inheritdoc />
    public partial class EMS_Initial_Migration_v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalDays",
                table: "Leaves",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDays",
                table: "Leaves");
        }
    }
}
