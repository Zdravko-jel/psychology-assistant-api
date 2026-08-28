using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class PatientFileUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f9f96fe-a6ef-4eac-8222-a5bc6461d69f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d8db6c2-87e1-4d5e-bdab-7032725db354");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClosedOn",
                table: "PatientFiles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dde1bd1-f2b3-4fe7-a163-9e67f4136889", null, "User", "USER" },
                    { "2cf0e981-8009-4619-906d-36b6d0de72c1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dde1bd1-f2b3-4fe7-a163-9e67f4136889");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cf0e981-8009-4619-906d-36b6d0de72c1");

            migrationBuilder.DropColumn(
                name: "ClosedOn",
                table: "PatientFiles");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f9f96fe-a6ef-4eac-8222-a5bc6461d69f", null, "Admin", "ADMIN" },
                    { "1d8db6c2-87e1-4d5e-bdab-7032725db354", null, "User", "USER" }
                });
        }
    }
}
