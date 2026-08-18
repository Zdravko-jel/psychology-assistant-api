using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46760289-33cd-45b5-b027-fb8c92c69036");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a5bf3b20-f296-4cd1-9b8f-40824a5e597e");

            migrationBuilder.RenameColumn(
                name: "WorkingHours",
                table: "AspNetUsers",
                newName: "WorkingHoursStart");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "WorkingHoursEnd",
                table: "AspNetUsers",
                type: "time",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "827c0aa2-9f26-4270-bde7-4a4e954c7d9f", null, "User", "USER" },
                    { "9f4fc27c-ffc2-4984-82b8-f3c6bc4c95f6", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "827c0aa2-9f26-4270-bde7-4a4e954c7d9f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9f4fc27c-ffc2-4984-82b8-f3c6bc4c95f6");

            migrationBuilder.DropColumn(
                name: "WorkingHoursEnd",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "WorkingHoursStart",
                table: "AspNetUsers",
                newName: "WorkingHours");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46760289-33cd-45b5-b027-fb8c92c69036", null, "Admin", "ADMIN" },
                    { "a5bf3b20-f296-4cd1-9b8f-40824a5e597e", null, "User", "USER" }
                });
        }
    }
}
