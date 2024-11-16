using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LorryGlory.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobTitle = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressStreet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_AddressCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
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
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UriLink = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    LinkedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinkedEntityType = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Vin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeClass = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleYear = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    StolenStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status_FirstRegistered = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_LatestInspection = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_InspectionValidUntil = table.Column<DateOnly>(type: "date", nullable: true),
                    Inspection_Meter = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_PowerHp = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_PowerKw = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_CylinderVolume = table.Column<int>(type: "int", nullable: true),
                    TechnicalData_Fuel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData_Transmission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnicalData_FourWheelDrive = table.Column<bool>(type: "bit", nullable: true),
                    TechnicalData_Chassi = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    TechnicalData_Category = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_JobTasks_Jobs_FK_JobId",
                        column: x => x.FK_JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTasks_Vehicles_FK_VehicleId",
                        column: x => x.FK_VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "JobTaskReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_JobTaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FK_TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FK_FileLink = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UpdatedById = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffMemberId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTaskReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTaskReports_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTaskReports_AspNetUsers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_JobTaskReports_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTaskReports_Companies_FK_TenantId",
                        column: x => x.FK_TenantId,
                        principalTable: "Companies",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTaskReports_FileLinks_FK_FileLink",
                        column: x => x.FK_FileLink,
                        principalTable: "FileLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTaskReports_JobTasks_FK_JobTaskId",
                        column: x => x.FK_JobTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "TenantId", "CompanyName", "OrganizationNumber", "PhoneNumber" },
                values: new object[] { new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), "Lorry Glory AB", "11-111", "0761" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FK_TenantId", "FirstName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PersonalNumber", "PhoneNumber", "PhoneNumberConfirmed", "PreferredLanguage", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address_AddressCity", "Address_AddressCountry", "Address_AddressStreet", "Address_PostalCode" },
                values: new object[] { "1STAFFM", 0, "5af874b3-e06e-41d1-99cf-d8369b0bf339", "magda@m.m", false, new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), "Magda", 2, "Kubien", false, null, null, null, null, "YYYYMMDD-0000", null, false, "PL", "aaba4e3c-bdb1-4c67-be63-23bb1fc66a94", false, "magda@m.m", "Kato", "PL", "Vägen till ingenstans", "44444" });

            migrationBuilder.InsertData(
                table: "FileLinks",
                columns: new[] { "Id", "FK_TenantId", "LinkedEntityId", "LinkedEntityType", "Name", "UriLink" },
                values: new object[] { new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"), "JobTask", "test-file.pdf", "https://example.com/test-file.pdf" });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "ActualTotalTime", "CreatedAt", "Description", "EstimatedTotalTime", "FK_ClientId", "FK_FileLink", "FK_TenantId", "IsCompleted", "Status", "UpdatedAt" },
                values: new object[] { new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test Job", null, null, null, new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), false, null, null });

            migrationBuilder.InsertData(
                table: "JobTasks",
                columns: new[] { "Id", "CreatedAt", "Description", "EndTime", "FK_FileLink", "FK_JobId", "FK_StaffMemberId", "FK_TenantId", "FK_VehicleId", "IsCompleted", "StartTime", "Status", "Title", "UpdatedAt", "ContactPerson_Email", "ContactPerson_Name", "ContactPerson_PhoneNumber", "DeliveryAddress_AddressCity", "DeliveryAddress_AddressCountry", "DeliveryAddress_AddressStreet", "DeliveryAddress_PostalCode", "PickupAddress_AddressCity", "PickupAddress_AddressCountry", "PickupAddress_AddressStreet", "PickupAddress_PostalCode" },
                values: new object[] { new Guid("9a2b0228-4d0d-4c23-8b49-01a698857709"), new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), "Test delivery task", new DateTime(2024, 11, 15, 18, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), new Guid("5d2b0228-4d0d-4c23-8b49-01a698857709"), new Guid("1a2b0228-4d0d-4c23-8b49-01a698857709"), "1STAFFM", new Guid("1d2b0228-4d0d-4c23-8b49-01a698857709"), null, false, new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), 666, "Delivery Task", new DateTime(2024, 11, 15, 16, 59, 43, 983, DateTimeKind.Local).AddTicks(5553), "john@example.com", "John Doe", null, "Delivery City", "Sweden", "Delivery Street 2", "67890", "Pickup City", "Sweden", "Pickup Street 1", "12345" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_FK_TenantId",
                table: "Clients",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_FileLinks_FK_TenantId_LinkedEntityType_LinkedEntityId",
                table: "FileLinks",
                columns: new[] { "FK_TenantId", "LinkedEntityType", "LinkedEntityId" },
                unique: true);

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
                name: "IX_JobTaskReports_CreatedById",
                table: "JobTaskReports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_FK_FileLink",
                table: "JobTaskReports",
                column: "FK_FileLink");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_FK_JobTaskId",
                table: "JobTaskReports",
                column: "FK_JobTaskId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_FK_TenantId",
                table: "JobTaskReports",
                column: "FK_TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_StaffMemberId",
                table: "JobTaskReports",
                column: "StaffMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTaskReports_UpdatedById",
                table: "JobTaskReports",
                column: "UpdatedById");

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

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_RegNo",
                table: "Vehicles",
                column: "RegNo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "JobTaskReports");

            migrationBuilder.DropTable(
                name: "StaffRelations");

            migrationBuilder.DropTable(
                name: "VehicleProblems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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
        }
    }
}
