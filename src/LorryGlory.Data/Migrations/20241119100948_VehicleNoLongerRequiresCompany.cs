using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleNoLongerRequiresCompany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c0164b93-bb43-48d7-8e54-4095ff7b7776", "7186375a-03b8-4977-aad8-a0b77c5efd20" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 19, 11, 9, 47, 263, DateTimeKind.Local).AddTicks(4583), new DateTime(2024, 11, 19, 13, 9, 47, 263, DateTimeKind.Local).AddTicks(4583), new DateTime(2024, 11, 19, 11, 9, 47, 263, DateTimeKind.Local).AddTicks(4583), new DateTime(2024, 11, 19, 11, 9, 47, 263, DateTimeKind.Local).AddTicks(4583) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
