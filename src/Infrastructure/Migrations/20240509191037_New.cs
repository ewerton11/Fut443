using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("53902441-027a-4fd5-9642-713464735edc"));

            migrationBuilder.AddColumn<int>(
                name: "Season",
                table: "Round",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash" },
                values: new object[] { new Guid("bbaf0c31-e3d9-4e05-9241-8fd5ce4725d8"), "ewerton@gmail.com", "ewerton", "Root", 3, "$2a$11$1FDhA.P3Q1vMN7.UkbK6kuUktcVdUgLct8HVZySx6YRqNwyT1p42q" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("bbaf0c31-e3d9-4e05-9241-8fd5ce4725d8"));

            migrationBuilder.DropColumn(
                name: "Season",
                table: "Round");

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash" },
                values: new object[] { new Guid("53902441-027a-4fd5-9642-713464735edc"), "ewerton@gmail.com", "ewerton", "Root", 3, "$2a$11$osBGd1LGsyoRSXZlp0vW8OpgRzP3UcPNDhQYZCwRnt1fS6YTh0rQu" });
        }
    }
}
