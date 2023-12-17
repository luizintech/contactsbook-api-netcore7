using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactBook.EFCore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DumpContactTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ContactTypes",
                columns: new[] { "Id", "CreatedAt", "Description" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 17, 9, 28, 0, 50, DateTimeKind.Local).AddTicks(3315), "Email" },
                    { 2, new DateTime(2023, 12, 17, 9, 28, 0, 50, DateTimeKind.Local).AddTicks(3318), "Phone" },
                    { 3, new DateTime(2023, 12, 17, 9, 28, 0, 50, DateTimeKind.Local).AddTicks(3320), "Home Phone" },
                    { 4, new DateTime(2023, 12, 17, 9, 28, 0, 50, DateTimeKind.Local).AddTicks(3322), "Whatsapp" },
                    { 5, new DateTime(2023, 12, 17, 9, 28, 0, 50, DateTimeKind.Local).AddTicks(3325), "Skype ID" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ContactTypes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
