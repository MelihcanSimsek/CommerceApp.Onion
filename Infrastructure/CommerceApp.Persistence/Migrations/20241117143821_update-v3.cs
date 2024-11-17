using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatev3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(6202), "Music, Toys & Garden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(6286), "Toys & Outdoors" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Name" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(6302), "Industrial & Beauty" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(7924));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(7927));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(7928));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 11, 17, 17, 38, 21, 420, DateTimeKind.Local).AddTicks(7930));

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 422, DateTimeKind.Local).AddTicks(4653), "Sint illum dolor vero atque id et quia at aut.", "Ut." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 422, DateTimeKind.Local).AddTicks(4798), "Perspiciatis odit repudiandae officiis molestias deleniti repellat.", "Voluptatem molestiae." });

            migrationBuilder.UpdateData(
                table: "Details",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationDate", "Description", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 422, DateTimeKind.Local).AddTicks(4842), "Asperiores possimus in ad sequi.", "Vitae ex optio." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 425, DateTimeKind.Local).AddTicks(1945), "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", 4.97m, 55.31m, "Tasty Frozen Chips" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationDate", "Description", "Discount", "Price", "Title" },
                values: new object[] { new DateTime(2024, 11, 17, 17, 38, 21, 425, DateTimeKind.Local).AddTicks(2052), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", 7.98m, 43.82m, "Licensed Fresh Bacon" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
