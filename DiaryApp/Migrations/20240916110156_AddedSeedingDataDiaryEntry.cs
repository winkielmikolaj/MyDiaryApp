using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiaryApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedingDataDiaryEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DiaryEntries",
                columns: new[] { "Id", "Content", "Created", "Title" },
                values: new object[,]
                {
                    { 1, "Went hiking with John Doe", new DateTime(2024, 9, 16, 11, 1, 56, 363, DateTimeKind.Utc).AddTicks(4360), "Went Hiking" },
                    { 2, "Went shoping with John Doe", new DateTime(2024, 9, 16, 11, 1, 56, 363, DateTimeKind.Utc).AddTicks(4362), "Went Shoping" },
                    { 3, "Went diving with John Doe", new DateTime(2024, 9, 16, 11, 1, 56, 363, DateTimeKind.Utc).AddTicks(4364), "Went Diving" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DiaryEntries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
