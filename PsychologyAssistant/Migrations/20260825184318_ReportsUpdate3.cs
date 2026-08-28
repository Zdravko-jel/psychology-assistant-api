using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ReportsUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75681675-0448-4488-82c6-1327a6290dc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8d72c5f-cd55-416b-a8ae-8e953dc32cde");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f9f96fe-a6ef-4eac-8222-a5bc6461d69f", null, "Admin", "ADMIN" },
                    { "1d8db6c2-87e1-4d5e-bdab-7032725db354", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f9f96fe-a6ef-4eac-8222-a5bc6461d69f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d8db6c2-87e1-4d5e-bdab-7032725db354");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reports");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "75681675-0448-4488-82c6-1327a6290dc7", null, "User", "USER" },
                    { "e8d72c5f-cd55-416b-a8ae-8e953dc32cde", null, "Admin", "ADMIN" }
                });
        }
    }
}
