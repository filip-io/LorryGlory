using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class nullableTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobTasks",
                keyColumn: "Id",
                keyValue: new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1STAFFM");

            migrationBuilder.DeleteData(
                table: "FileLinks",
                keyColumn: "Id",
                keyValue: new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"));

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"));

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "TenantId",
                keyValue: new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"));

            migrationBuilder.AlterColumn<Guid>(
                name: "FK_TenantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "FK_TenantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "TenantId", "CompanyName", "OrganizationNumber", "PhoneNumber" },
                values: new object[] { new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), "Lorry Glory AB", "11-111", "0761" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FK_TenantId", "FirstName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "PreferredLanguage", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address_AddressCity", "Address_AddressCountry", "Address_AddressStreet", "Address_PostalCode" },
                values: new object[] { "1STAFFM", 0, "ef2faa8a-e89b-4f18-a432-44e8f47ccfa1", "magda@m.m", false, new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), "Magda", 2, "Kubien", false, null, null, null, null, "YYYYMMDD-0000", null, false, "PL", "f154ae02-283d-464f-990a-fc7bc5c3ee0e", false, "magda@m.m", "Kato", "PL", "Vägen till ingenstans", "44444" });

            migrationBuilder.InsertData(
                table: "FileLinks",
                columns: new[] { "Id", "FK_TenantId", "LinkedEntityId", "LinkedEntityType", "Name", "UriLink" },
                values: new object[] { new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"), "JobTask", "test-file.pdf", "https://example.com/test-file.pdf" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "ActualTotalTime", "CreatedAt", "Description", "EndTime", "EstimatedTotalTime", "FK_ClientId", "FK_FileLink", "FK_TenantId", "IsCompleted", "StartTime", "Status", "Title", "UpdatedAt" },
                values: new object[] { new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Job", null, null, null, null, new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), false, null, null, null, null });

            migrationBuilder.InsertData(
                table: "JobTasks",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "FK_FileLink", "FK_JobId", "FK_StaffMemberId", "FK_TenantId", "FK_VehicleId", "IsCompleted", "StartTime", "Status", "Title", "UpdatedAt", "ContactPerson_Email", "ContactPerson_Name", "ContactPerson_PhoneNumber", "DeliveryAddress_AddressCity", "DeliveryAddress_AddressCountry", "DeliveryAddress_AddressStreet", "DeliveryAddress_PostalCode", "PickupAddress_AddressCity", "PickupAddress_AddressCountry", "PickupAddress_AddressStreet", "PickupAddress_PostalCode" },
                values: new object[] { new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"), new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), "Test delivery task", new DateTime(2024, 11, 20, 17, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"), "1STAFFM", new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), null, false, new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), 666, "Delivery Task", new DateTime(2024, 11, 20, 15, 31, 28, 316, DateTimeKind.Local).AddTicks(1768), "john@example.com", "John Doe", null, "Delivery City", "Sweden", "Delivery Street 2", "67890", "Pickup City", "Sweden", "Pickup Street 1", "12345" });
        }
    }
}
