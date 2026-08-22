using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2da07cb6-0edd-456e-a761-b336d4191ed4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75e046d2-5d1d-4eec-bb5c-809c4e978b6e");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "59745417-c821-4b19-b0b3-6823e8a45f8c", null, "Admin", "ADMIN" },
                    { "645155f0-32c1-4605-a56b-daec04c873e2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59745417-c821-4b19-b0b3-6823e8a45f8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "645155f0-32c1-4605-a56b-daec04c873e2");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Patients");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2da07cb6-0edd-456e-a761-b336d4191ed4", null, "User", "USER" },
                    { "75e046d2-5d1d-4eec-bb5c-809c4e978b6e", null, "Admin", "ADMIN" }
                });
        }
    }
}
