using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class AddReports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35f5f51d-e680-4e48-8a7a-252659ca0aa6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e82c37dc-6c22-4fa7-a612-b183927ba9c2");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPatientsIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionsIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiagnosesIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClosedFilesIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5656f0fc-2868-4b69-9e0a-85bb30f9177f", null, "User", "USER" },
                    { "93862137-ab0a-4b57-848a-421a6041a473", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5656f0fc-2868-4b69-9e0a-85bb30f9177f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93862137-ab0a-4b57-848a-421a6041a473");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "35f5f51d-e680-4e48-8a7a-252659ca0aa6", null, "User", "USER" },
                    { "e82c37dc-6c22-4fa7-a612-b183927ba9c2", null, "Admin", "ADMIN" }
                });
        }
    }
}
