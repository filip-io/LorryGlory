using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntityConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_PostalCode",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressStreet",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressCountry",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressCity",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FK_StaffMemberId",
                table: "JobTasks",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_PostalCode",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressStreet",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressCountry",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressCity",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_PostalCode",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressStreet",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressCountry",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PickupAddress_AddressCity",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FK_StaffMemberId",
                table: "JobTasks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_PostalCode",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressStreet",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressCountry",
                table: "JobTasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliveryAddress_AddressCity",
                table: "JobTasks",
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
                values: new object[] { "5af874b3-e06e-41d1-99cf-d8369b0bf339", "aaba4e3c-bdb1-4c67-be63-23bb1fc66a94" });

            migrationBuilder.UpdateData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"),
                columns: new[] { "CreatedAt", "EndTime", "StartTime", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), new DateTime(2024, 11, 15, 18, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553) });
        }
    }
}
