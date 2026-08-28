using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PsychologyAssistant.Migrations
{
    /// <inheritdoc />
    public partial class PatientFileUpdate5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientFiles_Diagnoses_DiagnosisId",
                table: "PatientFiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0dde1bd1-f2b3-4fe7-a163-9e67f4136889");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cf0e981-8009-4619-906d-36b6d0de72c1");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "PatientFiles",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6b416055-620e-4293-bb55-f9fa79d48faf", null, "Admin", "ADMIN" },
                    { "f7a09fe6-c0e6-4375-be3d-9a9585024fcc", null, "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientFiles_Diagnoses_DiagnosisId",
                table: "PatientFiles",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientFiles_Diagnoses_DiagnosisId",
                table: "PatientFiles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b416055-620e-4293-bb55-f9fa79d48faf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7a09fe6-c0e6-4375-be3d-9a9585024fcc");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "PatientFiles",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0dde1bd1-f2b3-4fe7-a163-9e67f4136889", null, "User", "USER" },
                    { "2cf0e981-8009-4619-906d-36b6d0de72c1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PatientFiles_Diagnoses_DiagnosisId",
                table: "PatientFiles",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id");
        }
    }
}
