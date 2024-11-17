using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateproductcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(3867), "Shoes, Sports & Industrial" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(3977), "Music, Computers & Outdoors" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(3994), "Tools, Computers & Tools" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(7408));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(7410));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 34, 10, 76, DateTimeKind.Local).AddTicks(7431));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 78, DateTimeKind.Local).AddTicks(5244), "Quo et aut est at deserunt maiores dolor eum voluptatibus.", "Rem." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 78, DateTimeKind.Local).AddTicks(5399), "Cumque quia sint quasi delectus et veniam.", "Molestiae nihil." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 78, DateTimeKind.Local).AddTicks(5446), "Deserunt qui nobis voluptas voluptas.", "Quis earum ut." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 81, DateTimeKind.Local).AddTicks(2889), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", 6.04m, 51.19m, "Practical Soft Mouse" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 34, 10, 81, DateTimeKind.Local).AddTicks(2998), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", 1.70m, 36.79m, "Ergonomic Frozen Pizza" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    CategoriesId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.CategoriesId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 296, DateTimeKind.Local).AddTicks(8503), "Clothing, Garden & Electronics" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 296, DateTimeKind.Local).AddTicks(8895), "Sports & Grocery" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 296, DateTimeKind.Local).AddTicks(8920), "Computers, Toys & Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 11, 16, 23, 57, 9, 297, DateTimeKind.Local).AddTicks(728));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 11, 16, 23, 57, 9, 297, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 11, 16, 23, 57, 9, 297, DateTimeKind.Local).AddTicks(733));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 11, 16, 23, 57, 9, 297, DateTimeKind.Local).AddTicks(735));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 298, DateTimeKind.Local).AddTicks(4900), "Et delectus sapiente omnis perferendis ab saepe sit culpa exercitationem.", "Doloremque." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 298, DateTimeKind.Local).AddTicks(5051), "Dolorem velit omnis consequuntur laboriosam qui sint.", "Consequatur ratione." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 298, DateTimeKind.Local).AddTicks(5097), "Optio repellat exercitationem et est.", "Aut consequatur praesentium." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 300, DateTimeKind.Local).AddTicks(1456), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", 7.71m, 19.29m, "Refined Fresh Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 16, 23, 57, 9, 300, DateTimeKind.Local).AddTicks(1551), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", 7.56m, 81.76m, "Ergonomic Soft Towels" });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_ProductsId",
                table: "CategoryProduct",
                column: "ProductsId");
        }
    }
}
