using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project2_NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataintoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("5da9fbdb-6205-4895-b796-eea51ade662d"), "Easy" },
                    { new Guid("be7d05a5-0ba6-472f-8157-9af1070ba722"), "Hard" },
                    { new Guid("ed90a2b2-2b5c-4cec-9835-0fc61ebe9cc3"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageURL" },
                values: new object[,]
                {
                    { new Guid("1d0fe942-3a4c-44f8-b12e-be421e533b5f"), "LA", "Lagos", "https://lagos.jpeg" },
                    { new Guid("1ea9f4f7-a277-4255-a812-80d54b6de6ed"), "KW", "Kwara", "https://kwara.jpeg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("5da9fbdb-6205-4895-b796-eea51ade662d"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("be7d05a5-0ba6-472f-8157-9af1070ba722"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ed90a2b2-2b5c-4cec-9835-0fc61ebe9cc3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1d0fe942-3a4c-44f8-b12e-be421e533b5f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1ea9f4f7-a277-4255-a812-80d54b6de6ed"));
        }
    }
}
