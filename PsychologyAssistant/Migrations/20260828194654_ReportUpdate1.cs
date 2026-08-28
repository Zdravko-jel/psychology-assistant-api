using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class ReportUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b416055-620e-4293-bb55-f9fa79d48faf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a09fe6-c0e6-4375-be3d-9a9585024fcc");

            migrationBuilder.DropColumn(
                name: "ClosedFilesIds",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "DiagnosesIds",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "NewPatientsIds",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "SessionsIds",
                table: "Reports");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3df7213b-8b5e-4229-8780-cfdaede1640c", null, "Admin", "ADMIN" },
                    { "b4f2b493-f10f-43ec-9249-98cd7deb71ca", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3df7213b-8b5e-4229-8780-cfdaede1640c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4f2b493-f10f-43ec-9249-98cd7deb71ca");

            migrationBuilder.AddColumn<string>(
                name: "ClosedFilesIds",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DiagnosesIds",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NewPatientsIds",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SessionsIds",
                table: "Reports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b416055-620e-4293-bb55-f9fa79d48faf", null, "Admin", "ADMIN" },
                    { "f7a09fe6-c0e6-4375-be3d-9a9585024fcc", null, "User", "USER" }
                });
        }
    }
}
