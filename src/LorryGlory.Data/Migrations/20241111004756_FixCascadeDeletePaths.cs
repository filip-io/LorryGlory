using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixCascadeDeletePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_AddressCity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressCountry",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_AddressStreet",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "FK_TenantId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "JobTitle",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredLanguage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.TenantId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FileLinks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UriLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LinkedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkedEntityType = table.Column<int>(type: "int", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FileLinks_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StaffId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Boss_StaffId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffRelations_AspNetUsers_Boss_StaffId",
                        column: x => x.Boss_StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StaffRelations_AspNetUsers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffRelations_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    StolenStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status_Status = table.Column<int>(type: "int", nullable: true),
                    Status_FirstRegistered = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_LatestInspection = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_InspectionValidUntil = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_Meter = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_PowerHp = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_PowerKw = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_CylinderVolume = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Fuel = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Transmission = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_FourWheelDrive = table.Column<bool>(type: "bit", nullable: true),
                    TechnicalData_Chassi = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Length = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Width = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Height = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_KerbWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_TotalWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_LoadWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_TrailerWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_UnbrakedTrailerWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_TrailerWeightB = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_TrailerWeightBe = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_CarriageWeight = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_TireFront = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData_TireBack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData_AxleWidth1 = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_AxleWidth2 = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_AxleWidth3 = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_FK_Category_Id = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Category_Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData_Category_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eco_EuroClass = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedTotalTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    ActualTotalTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    FK_ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_FileLink = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Clients_FK_ClientId",
                        column: x => x.FK_ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_FileLinks_FK_FileLink",
                        column: x => x.FK_FileLink,
                        principalTable: "FileLinks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehicleProblems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeverityLevel = table.Column<int>(type: "int", nullable: false),
                    FK_FileLink = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleProblems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleProblems_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleProblems_FileLinks_FK_FileLink",
                        column: x => x.FK_FileLink,
                        principalTable: "FileLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VehicleProblems_Vehicles_FK_VehicleId",
                        column: x => x.FK_VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ContactPerson_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactPerson_PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickupAddress_AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupAddress_AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PickupAddress_AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryAddress_AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_StaffMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FK_JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FK_FileLink = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    JobTaskReport_ReportedStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTaskReport_ReportedEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTaskReport_Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTaskReport_CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTaskReport_FK_CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTaskReport_CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobTaskReport_UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    JobTaskReport_FK_UpdatedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTaskReport_UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    JobTaskReport_FK_FileLink = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTasks_AspNetUsers_FK_StaffMemberId",
                        column: x => x.FK_StaffMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_AspNetUsers_JobTaskReport_CreatedById",
                        column: x => x.JobTaskReport_CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_AspNetUsers_JobTaskReport_UpdatedById",
                        column: x => x.JobTaskReport_UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_FileLinks_FK_FileLink",
                        column: x => x.FK_FileLink,
                        principalTable: "FileLinks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobTasks_FileLinks_JobTaskReport_FK_FileLink",
                        column: x => x.JobTaskReport_FK_FileLink,
                        principalTable: "FileLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Jobs_FK_JobId",
                        column: x => x.FK_JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTasks_Vehicles_FK_VehicleId",
                        column: x => x.FK_VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FK_TenantId",
                table: "AspNetUsers",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FK_TenantId",
                table: "Clients",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLinks_FK_TenantId",
                table: "FileLinks",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FK_ClientId",
                table: "Jobs",
                column: "FK_ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FK_FileLink",
                table: "Jobs",
                column: "FK_FileLink");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_FK_TenantId",
                table: "Jobs",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_FK_FileLink",
                table: "JobTasks",
                column: "FK_FileLink");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_FK_JobId",
                table: "JobTasks",
                column: "FK_JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_FK_StaffMemberId",
                table: "JobTasks",
                column: "FK_StaffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_FK_TenantId",
                table: "JobTasks",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_FK_VehicleId",
                table: "JobTasks",
                column: "FK_VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobTaskReport_CreatedById",
                table: "JobTasks",
                column: "JobTaskReport_CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobTaskReport_FK_FileLink",
                table: "JobTasks",
                column: "JobTaskReport_FK_FileLink");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobTaskReport_UpdatedById",
                table: "JobTasks",
                column: "JobTaskReport_UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRelations_Boss_StaffId",
                table: "StaffRelations",
                column: "Boss_StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRelations_FK_TenantId",
                table: "StaffRelations",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRelations_StaffId",
                table: "StaffRelations",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProblems_FK_FileLink",
                table: "VehicleProblems",
                column: "FK_FileLink");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProblems_FK_TenantId",
                table: "VehicleProblems",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleProblems_FK_VehicleId",
                table: "VehicleProblems",
                column: "FK_VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_FK_TenantId",
                table: "Vehicles",
                column: "FK_TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Companies_FK_TenantId",
                table: "AspNetUsers",
                column: "FK_TenantId",
                principalTable: "Companies",
                principalColumn: "TenantId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Companies_FK_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "StaffRelations");

            migrationBuilder.DropTable(
                name: "VehicleProblems");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "FileLinks");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FK_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_AddressCity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_AddressCountry",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_AddressStreet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FK_TenantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PersonalNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PreferredLanguage",
                table: "AspNetUsers");
        }
    }
}
