using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixJobTaskReportStaffRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StaffMemberId",
                table: "JobTaskReports",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Jobs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5fd68744-44b8-462e-9e16-644bf47084e8", "10c1f1da-04a3-4f8a-a1fa-cb1693b129c5" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 14, 23, 57, 46, 588, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 11, 15, 1, 57, 46, 588, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 11, 14, 23, 57, 46, 588, DateTimeKind.Local).AddTicks(4317), new DateTime(2024, 11, 14, 23, 57, 46, 588, DateTimeKind.Local).AddTicks(4317) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"),
                column: "Status",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_StaffMemberId",
                table: "JobTaskReports",
                column: "StaffMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTaskReports_AspNetUsers_StaffMemberId",
                table: "JobTaskReports",
                column: "StaffMemberId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTaskReports_AspNetUsers_StaffMemberId",
                table: "JobTaskReports");

            migrationBuilder.DropIndex(
                name: "IX_JobTaskReports_StaffMemberId",
                table: "JobTaskReports");

            migrationBuilder.DropColumn(
                name: "StaffMemberId",
                table: "JobTaskReports");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d5d823c-05c1-4f60-a6e8-abea43b6599a", "e6a49b39-edf4-49ea-926e-91a35fc94e56" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 12, 17, 40, 13, 52, DateTimeKind.Local).AddTicks(7315), new DateTime(2024, 11, 12, 19, 40, 13, 52, DateTimeKind.Local).AddTicks(7315), new DateTime(2024, 11, 12, 17, 40, 13, 52, DateTimeKind.Local).AddTicks(7315), new DateTime(2024, 11, 12, 17, 40, 13, 52, DateTimeKind.Local).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"),
                column: "Status",
                value: 0);
        }
    }
}
