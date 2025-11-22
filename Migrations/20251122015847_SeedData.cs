using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.EF.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "Description", "Name", "Weight" },
                values: new object[,]
                {
                    { new Guid("e29765db-6368-49b3-9a97-88f8be1ca891"), null, "Personal Activities", 60 },
                    { new Guid("e29765db-6368-49b3-9a97-88f8be1ca89d"), null, "Pending Activities", 50 }
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "TareaId", "CategoryId", "CreationDate", "Description", "TareaPriority", "Title" },
                values: new object[,]
                {
                    { new Guid("e29765db-6368-49b3-9a97-88f8be1ca810"), new Guid("e29765db-6368-49b3-9a97-88f8be1ca89d"), new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, 2, "Renew car insurance" },
                    { new Guid("e29765db-6368-49b3-9a97-88f8be1ca811"), new Guid("e29765db-6368-49b3-9a97-88f8be1ca891"), new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), null, 0, "Watch anime" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TareaId",
                keyValue: new Guid("e29765db-6368-49b3-9a97-88f8be1ca810"));

            migrationBuilder.DeleteData(
                table: "Task",
                keyColumn: "TareaId",
                keyValue: new Guid("e29765db-6368-49b3-9a97-88f8be1ca811"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e29765db-6368-49b3-9a97-88f8be1ca891"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "CategoryId",
                keyValue: new Guid("e29765db-6368-49b3-9a97-88f8be1ca89d"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Task",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");
        }
    }
}
