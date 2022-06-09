using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SagaOrchestrationDemo.Infrastructure.DataAccess.Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "SagaDemo");

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character(5)", fixedLength: true, maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "SagaDemo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ShipAddress = table.Column<string>(type: "character varying(60)", maxLength: 60, nullable: false),
                    ShipCity = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ShipCountry = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    ShipPostalCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    DiscountType = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false),
                    ShippingType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "SagaDemo",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "SagaDemo",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "SagaDemo",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "SagaDemo",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "SagaDemo",
                table: "Customer",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { new Guid("f3c5a1e5-f16a-4a33-bb44-f12a2d70b65b"), "ALFKI", "Alfreds F." },
                    { new Guid("62b03939-903f-4a0f-9e64-6f374ffd6a70"), "ANATR", "Ana Trujillo" },
                    { new Guid("d8299406-cbb9-4495-bf67-2d62146eb04a"), "ANTON", "Antonio Moreno" }
                });

            migrationBuilder.InsertData(
                schema: "SagaDemo",
                table: "Product",
                columns: new[] { "Id", "Name", "Quantity" },
                values: new object[,]
                {
                    { new Guid("c27b1dfc-133f-4bbd-b7f2-f8785db0f619"), "Chai", (short)10 },
                    { new Guid("8944de08-89b7-40a2-9305-b931491806c4"), "Chang", (short)30 },
                    { new Guid("4f46e716-5764-45a6-b1dc-a79693e95914"), "Aniseed Syrup", (short)15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                schema: "SagaDemo",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                schema: "SagaDemo",
                table: "OrderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "SagaDemo");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "SagaDemo");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "SagaDemo");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "SagaDemo");
        }
    }
}
