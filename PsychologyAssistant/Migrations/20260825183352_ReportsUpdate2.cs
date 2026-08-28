using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ReportsUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d89a7675-3842-4456-97f5-605cd9fa24f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eb2dd32b-6c1d-472f-82ed-413d4c9f20c1");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75681675-0448-4488-82c6-1327a6290dc7", null, "User", "USER" },
                    { "e8d72c5f-cd55-416b-a8ae-8e953dc32cde", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75681675-0448-4488-82c6-1327a6290dc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d72c5f-cd55-416b-a8ae-8e953dc32cde");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Reports");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d89a7675-3842-4456-97f5-605cd9fa24f6", null, "User", "USER" },
                    { "eb2dd32b-6c1d-472f-82ed-413d4c9f20c1", null, "Admin", "ADMIN" }
                });
        }
    }
}
