using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace G_NET_84_EF03.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Data_categories_instructors_Courses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[] { 1, "Programming fundamentals", "Programming", null });

            migrationBuilder.InsertData(
                table: "Instructor",
                columns: new[] { "Id", "Bio", "Email", "FullName", "JoinedDate" },
                values: new object[,]
                {
                    { 1, "Backend Developer", "ahmed@example.com", "Ahmed Mohamed", new DateOnly(2025, 1, 10) },
                    { 2, "Frontend Developer", "omar@example.com", "Omar Ali", new DateOnly(2025, 2, 15) },
                    { 3, null, "sara@example.com", "Sara Hassan", new DateOnly(2025, 3, 20) }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 2, "Backend development", "Backend", 1 },
                    { 3, "Frontend development", "Frontend", 1 },
                    { 4, "ASP.NET Core development", "ASP.NET Core", 2 },
                    { 5, "Angular development", "Angular", 3 }
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CategoryId", "Description", "InstructorId", "IsPublished", "Level", "Price", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, 2, "Learn C# basics", 1, true, 0, 500m, new DateOnly(2025, 5, 1), "C# Fundamentals" },
                    { 3, 2, "Learn SQL Server database", 3, false, 1, 700m, null, "SQL Server" },
                    { 4, 3, "Learn web design fundamentals", 2, true, 0, 400m, new DateOnly(2025, 7, 1), "HTML & CSS" },
                    { 2, 4, "Build Web APIs using ASP.NET Core", 1, true, 2, 1200m, new DateOnly(2025, 6, 1), "ASP.NET Core Web API" },
                    { 5, 5, "Learn Angular framework", 2, true, 1, 900m, new DateOnly(2025, 8, 1), "Angular Fundamentals" },
                    { 6, 5, "Advanced Angular concepts", 3, false, 2, 1500m, null, "Advanced Angular" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Instructor",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
