using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatientFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59745417-c821-4b19-b0b3-6823e8a45f8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "645155f0-32c1-4605-a56b-daec04c873e2");

            migrationBuilder.AddColumn<DateTime>(
                name: "DiagnosisAdded",
                table: "PatientFiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "PatientFiles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35f5f51d-e680-4e48-8a7a-252659ca0aa6", null, "User", "USER" },
                    { "e82c37dc-6c22-4fa7-a612-b183927ba9c2", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35f5f51d-e680-4e48-8a7a-252659ca0aa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82c37dc-6c22-4fa7-a612-b183927ba9c2");

            migrationBuilder.DropColumn(
                name: "DiagnosisAdded",
                table: "PatientFiles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "PatientFiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59745417-c821-4b19-b0b3-6823e8a45f8c", null, "Admin", "ADMIN" },
                    { "645155f0-32c1-4605-a56b-daec04c873e2", null, "User", "USER" }
                });
        }
    }
}
