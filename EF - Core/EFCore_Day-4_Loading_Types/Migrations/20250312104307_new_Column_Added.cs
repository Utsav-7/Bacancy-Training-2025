using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore_Day_4_Loading_Types.Migrations
{
    /// <inheritdoc />
    public partial class new_Column_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVIP",
                table: "customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "IsVIP",
                value: true);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "IsVIP",
                value: false);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "IsVIP",
                value: true);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "IsVIP",
                value: false);

            migrationBuilder.UpdateData(
                table: "customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "IsVIP",
                value: true);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stock",
                value: 25);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Stock",
                value: 120);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Stock",
                value: 18);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVIP",
                table: "customers");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stock",
                value: 5);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "Stock",
                value: 12);

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Stock",
                value: 8);
        }
    }
}
