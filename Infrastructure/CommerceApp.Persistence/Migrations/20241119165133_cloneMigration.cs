using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class cloneMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(2782), "Computers, Baby & Beauty" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(3374), "Health & Home" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(3423), "Garden & Home" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 11, 19, 19, 51, 31, 850, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 855, DateTimeKind.Local).AddTicks(880), "Suscipit corporis modi suscipit qui recusandae magnam voluptates error itaque.", "Explicabo." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 855, DateTimeKind.Local).AddTicks(1113), "Repellendus dolore est ipsam in aspernatur impedit.", "Harum magni." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 855, DateTimeKind.Local).AddTicks(1270), "Reiciendis excepturi quos et doloremque.", "Tempore omnis tempora." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 858, DateTimeKind.Local).AddTicks(8523), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", 5.12m, 81.88m, "Handcrafted Metal Chair" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 19, 19, 51, 31, 858, DateTimeKind.Local).AddTicks(8631), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", 6.03m, 80.04m, "Intelligent Steel Keyboard" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 449, DateTimeKind.Local).AddTicks(9542), "Sports, Grocery & Movies" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 449, DateTimeKind.Local).AddTicks(9957), "Tools, Automotive & Toys" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 449, DateTimeKind.Local).AddTicks(9982), "Music" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 11, 18, 22, 24, 44, 450, DateTimeKind.Local).AddTicks(2084));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 11, 18, 22, 24, 44, 450, DateTimeKind.Local).AddTicks(2086));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 11, 18, 22, 24, 44, 450, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 11, 18, 22, 24, 44, 450, DateTimeKind.Local).AddTicks(2090));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 452, DateTimeKind.Local).AddTicks(8894), "Ad assumenda illo voluptatem voluptas mollitia molestias doloribus dignissimos rerum.", "Maiores." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 452, DateTimeKind.Local).AddTicks(9117), "In facere recusandae qui rerum a non.", "Odit est." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 452, DateTimeKind.Local).AddTicks(9167), "Quibusdam vel minus facere incidunt.", "Nam voluptates delectus." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 456, DateTimeKind.Local).AddTicks(7163), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", 9.03m, 48.96m, "Refined Cotton Sausages" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 18, 22, 24, 44, 456, DateTimeKind.Local).AddTicks(7267), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", 1.53m, 14.32m, "Intelligent Concrete Chips" });
        }
    }
}
