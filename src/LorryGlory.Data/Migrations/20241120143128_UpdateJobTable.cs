using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateJobTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualEndTime",
                table: "JobTaskReports",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ActualStartTime",
                table: "JobTaskReports",
                type: "time",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ef2faa8a-e89b-4f18-a432-44e8f47ccfa1", "f154ae02-283d-464f-990a-fc7bc5c3ee0e" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 11, 20, 17, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768) });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "EndTime", "StartTime", "Title" },
                values: new object[] { null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualEndTime",
                table: "JobTaskReports");

            migrationBuilder.DropColumn(
                name: "ActualStartTime",
                table: "JobTaskReports");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Jobs");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Jobs",
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
                values: new object[] { "c9f574e6-f863-47c7-8623-b9f052e323ba", "e59c16ef-71a0-42fa-a616-d7856662579c" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 17, 1, 53, 55, 153, DateTimeKind.Local).AddTicks(3896), new DateTime(2024, 11, 17, 3, 53, 55, 153, DateTimeKind.Local).AddTicks(3896), new DateTime(2024, 11, 17, 1, 53, 55, 153, DateTimeKind.Local).AddTicks(3896), new DateTime(2024, 11, 17, 1, 53, 55, 153, DateTimeKind.Local).AddTicks(3896) });
        }
    }
}
