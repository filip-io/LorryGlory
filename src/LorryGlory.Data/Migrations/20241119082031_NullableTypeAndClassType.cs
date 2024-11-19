using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class NullableTypeAndClassType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeClass",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c3451588-692d-4b1c-a2a2-40c569b10bf8", "5caeeb0c-5257-4ec2-9955-a5c96fecf13c" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 19, 9, 20, 30, 45, DateTimeKind.Local).AddTicks(6929), new DateTime(2024, 11, 19, 11, 20, 30, 45, DateTimeKind.Local).AddTicks(6929), new DateTime(2024, 11, 19, 9, 20, 30, 45, DateTimeKind.Local).AddTicks(6929), new DateTime(2024, 11, 19, 9, 20, 30, 45, DateTimeKind.Local).AddTicks(6929) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TypeClass",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Vehicles",
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
                values: new object[] { "b8cd87bf-b671-466e-9e06-bff159186bc8", "bd36c4ff-e1a4-4533-80c2-0c701da852ad" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 17, 15, 46, 56, 229, DateTimeKind.Local).AddTicks(8564), new DateTime(2024, 11, 17, 17, 46, 56, 229, DateTimeKind.Local).AddTicks(8564), new DateTime(2024, 11, 17, 15, 46, 56, 229, DateTimeKind.Local).AddTicks(8564), new DateTime(2024, 11, 17, 15, 46, 56, 229, DateTimeKind.Local).AddTicks(8564) });
        }
    }
}
