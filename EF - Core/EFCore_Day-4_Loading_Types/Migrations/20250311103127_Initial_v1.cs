using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCore_Day_4_Loading_Types.Migrations
{
    /// <inheritdoc />
    public partial class Initial_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_orders_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_orderProducts_orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderProducts_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "CustomerId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "jay@gmail.com", "Jay" },
                    { 2, "mahesh@gmail.com", "Mahesh" },
                    { 3, "raju@gmail.com", "Raju" },
                    { 4, "mukesh@gmail.com", "Mukesh" },
                    { 5, "suresh@gmail.com", "Suresh" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, "Laptop", 49999.00m, 1 },
                    { 2, "Smartphone", 29999.00m, 5 },
                    { 3, "Headphones", 1999.99m, 10 },
                    { 4, "Keyboard", 1499.50m, 15 },
                    { 5, "Mouse", 799.75m, 20 },
                    { 6, "Monitor", 8999.99m, 7 },
                    { 7, "Printer", 12999.00m, 3 },
                    { 8, "Speaker", 2999.49m, 12 },
                    { 9, "Webcam", 2499.99m, 8 },
                    { 10, "External Hard Drive", 6999.99m, 6 }
                });

            migrationBuilder.InsertData(
                table: "orders",
                columns: new[] { "OrderId", "CustomerId", "IsDeleted", "OrderDate" },
                values: new object[,]
                {
                    { 1, 1, false, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, false, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, false, new DateTime(2023, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, false, new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, false, new DateTime(2023, 12, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 2, false, new DateTime(2023, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 3, false, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 5, false, new DateTime(2023, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "orderProducts",
                columns: new[] { "OrderId", "ProductId", "Id", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 },
                    { 3, 3, 3, 1 },
                    { 4, 4, 4, 3 },
                    { 5, 5, 5, 2 },
                    { 6, 6, 6, 1 },
                    { 7, 7, 7, 4 },
                    { 8, 8, 8, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_customers_Email",
                table: "customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_orderProducts_ProductId",
                table: "orderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orders_CustomerId",
                table: "orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderProducts");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
