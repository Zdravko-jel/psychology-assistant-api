using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ReportsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5656f0fc-2868-4b69-9e0a-85bb30f9177f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93862137-ab0a-4b57-848a-421a6041a473");

            migrationBuilder.AddColumn<string>(
                name: "storedFileName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d89a7675-3842-4456-97f5-605cd9fa24f6", null, "User", "USER" },
                    { "eb2dd32b-6c1d-472f-82ed-413d4c9f20c1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d89a7675-3842-4456-97f5-605cd9fa24f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb2dd32b-6c1d-472f-82ed-413d4c9f20c1");

            migrationBuilder.DropColumn(
                name: "storedFileName",
                table: "Reports");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5656f0fc-2868-4b69-9e0a-85bb30f9177f", null, "User", "USER" },
                    { "93862137-ab0a-4b57-848a-421a6041a473", null, "Admin", "ADMIN" }
                });
        }
    }
}
