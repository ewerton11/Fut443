using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Newcolum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("6d93021f-9085-4413-8858-31816f729b4b"));

            migrationBuilder.AddColumn<bool>(
                name: "IsTeamBuildingClosed",
                table: "Round",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash" },
                values: new object[] { new Guid("53902441-027a-4fd5-9642-713464735edc"), "ewerton@gmail.com", "ewerton", "Root", 3, "$2a$11$osBGd1LGsyoRSXZlp0vW8OpgRzP3UcPNDhQYZCwRnt1fS6YTh0rQu" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: new Guid("53902441-027a-4fd5-9642-713464735edc"));

            migrationBuilder.DropColumn(
                name: "IsTeamBuildingClosed",
                table: "Round");

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Level", "PasswordHash" },
                values: new object[] { new Guid("6d93021f-9085-4413-8858-31816f729b4b"), "ewerton@gmail.com", "ewerton", "Root", 3, "$2a$11$MhwBYKX1UkQNI8lu2dDYp.liJe8u1o9LUZQD/BjVUPuBNw8E0zZJu" });
        }
    }
}
