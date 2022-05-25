using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shopping");

            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "shopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductQuanity = table.Column<int>(type: "int", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "DateTime", nullable: true),
                    GrandTotal = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "shopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OderDetail",
                schema: "shopping",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quanity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true),
                    SubTotal = table.Column<decimal>(type: "decimal(8,3)", precision: 8, scale: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderDetail",
                        column: x => x.OrderId,
                        principalSchema: "shopping",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_OrderDetail",
                        column: x => x.ProductId,
                        principalSchema: "shopping",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_OderDetail_OrderId",
                schema: "shopping",
                table: "OderDetail",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OderDetail_ProductId",
                schema: "shopping",
                table: "OderDetail",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OderDetail",
                schema: "shopping");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "shopping");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "shopping");
        }
    }
}
