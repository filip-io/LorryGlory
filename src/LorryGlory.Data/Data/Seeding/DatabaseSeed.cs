using LorryGlory.Data.Models;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.JobModels.Enums;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.StaffModels.Enums;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Models.VehicleModels.Enums;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Data.Seeding
{
    public static class DatabaseSeed
    {

        // Known GUIDs for relationships
        private static readonly Guid CompanyTenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709");
        private static readonly Guid VehicleId = new Guid("3D2B0228-4D0D-4C23-8B49-01A698857709");
        private static readonly Guid VehicleProblemId = new Guid("6D2B0228-4D0D-4C23-8B49-01A698857709");
        private static readonly Guid JobId = new Guid("1A2B0228-4D0D-4C23-8B49-01A698857709");
        private static readonly Guid JobTaskId = new Guid("9A2B0228-4D0D-4C23-8B49-01A698857709");
        private static readonly Guid FileLinkId = new Guid("5D2B0228-4D0D-4C23-8B49-01A698857709");

        public static void SeedData(this ModelBuilder modelBuilder)
        {
            SeedCompanies(modelBuilder);
            SeedVehicles(modelBuilder);
            SeedVehicleProblems(modelBuilder);
            SeedFileLinks(modelBuilder);
            SeedStaffMembers(modelBuilder);
            SeedJobs(modelBuilder);
            SeedJobTasks(modelBuilder);
        }

        private static void SeedCompanies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    TenantId = CompanyTenantId,
                    CompanyName = "Lorry Glory AB",
                    OrganizationNumber = "11-111",
                    PhoneNumber = "0761"
                }
            );
        }

        private static void SeedVehicles(ModelBuilder modelBuilder)
        {
            // First seed the owned types
            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.Status).HasData(
                new
                {
                    VehicleId = VehicleId,
                    Status = Status.I_Trafik,  // Updated to match enum
                    FirstRegistered = DateOnly.FromDateTime(DateTime.Parse("2020-01-01"))
                }
            );

            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.Inspection).HasData(
                new
                {
                    VehicleId = VehicleId,
                    LatestInspection = DateOnly.FromDateTime(DateTime.Parse("2023-01-01")),
                    InspectionValidUntil = DateOnly.FromDateTime(DateTime.Parse("2024-01-01")),
                    Meter = 150000  // In kilometers
                }
            );

            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.TechnicalData).HasData(
                new
                {
                    VehicleId = VehicleId,
                    PowerHp = 450,
                    PowerKw = 335,
                    CylinderVolume = 13000,
                    Fuel = FuelType.Diesel,     // Using enum
                    Transmission = TransmissionType.Manuell,  // Using enum
                    FourWheelDrive = true,
                    Chassi = ChassiType.Lastbil,  // Using enum
                    Length = 16500,  // mm
                    Width = 2550,    // mm
                    Height = 4000,   // mm
                    KerbWeight = 7500,   // kg
                    TotalWeight = 40000,
                    LoadWeight = 32500,
                    TrailerWeight = 36000,
                    UnbrakedTrailerWeight = 750,
                    TrailerWeightB = 3500,
                    TrailerWeightBe = 3500,
                    CarriageWeight = 40000,
                    TireFront = "315/80R22.5",
                    TireBack = "315/80R22.5",
                    AxleWidth1 = 3600,
                    AxleWidth2 = 1350,
                    AxleWidth3 = 0,
                    FK_Category_Id = 1
                }
            );

            modelBuilder.Entity<Vehicle>().OwnsOne(v => v.Eco).HasData(
                new
                {
                    VehicleId = VehicleId,
                    EuroClass = "6"
                }
            );

            // Main Vehicle entity
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle
                {
                    Id = VehicleId,
                    RegNo = "ABC123",
                    Vin = "YS2R4X20009176429",
                    Make = "Scania",
                    Model = "R450",
                    Color = "RED",
                    Type = "DRAGBIL",
                    TypeClass = "LASTBIL",
                    VehicleYear = 2020,
                    ModelYear = 2020,
                    StolenStatus = "NOT_STOLEN",
                    FK_TenantId = CompanyTenantId
                }
            );
        }

        private static void SeedVehicleProblems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleProblem>().HasData(
                new VehicleProblem
                {
                    Id = VehicleProblemId,
                    Title = "Brake System Warning",
                    Description = "Front brake pads showing significant wear",
                    SeverityLevel = 2,
                    FK_FileLink = FileLinkId,  // Optional - can be null
                    FK_VehicleId = VehicleId,
                    FK_TenantId = CompanyTenantId
                }
            );
        }

        private static void SeedFileLinks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileLink>().HasData(
                new FileLink
                {
                    Id = FileLinkId,
                    Name = "test-file.pdf",
                    UriLink = "https://example.com/test-file.pdf",
                    LinkedEntityId = JobTaskId,
                    LinkedEntityType = FileLinkType.JobTask,
                    FK_TenantId = CompanyTenantId
                }
            );
        }

        private static void SeedStaffMembers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffMember>().HasData(
                new StaffMember
                {
                    Id = "1STAFFM",
                    JobTitle = JobTitle.Driver,
                    FirstName = "Magda",
                    LastName = "Kubien",
                    PersonalNumber = "YYYYMMDD-0000",
                    PreferredLanguage = "PL",
                    FK_TenantId = CompanyTenantId,
                    Email = "magda@m.m",
                    UserName = "magda@m.m"
                }
            );

            modelBuilder.Entity<StaffMember>().OwnsOne(sm => sm.Address).HasData(
                new
                {
                    StaffMemberId = "1STAFFM",
                    AddressCity = "Kato",
                    PostalCode = "44444",
                    AddressCountry = "PL",
                    AddressStreet = "Vägen till ingenstans"
                }
            );
        }

        private static void SeedJobs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>().HasData(
                new Job
                {
                    Id = JobId,
                    IsCompleted = false,
                    Description = "Test Job",
                    FK_TenantId = CompanyTenantId
                }
            );
        }

        private static void SeedJobTasks(ModelBuilder modelBuilder)
        {
            var now = DateTime.Now;

            // Seed the owned types (Address and ContactPerson) first
            modelBuilder.Entity<JobTask>().OwnsOne(jt => jt.ContactPerson).HasData(
                new
                {
                    JobTaskId = JobTaskId,
                    Name = "John Doe",
                    Email = "john@example.com",
                    Phone = "123-456-7890"
                }
            );

            modelBuilder.Entity<JobTask>().OwnsOne(jt => jt.PickupAddress).HasData(
                new
                {
                    JobTaskId = JobTaskId,
                    AddressStreet = "Pickup Street 1",
                    AddressCity = "Pickup City",
                    PostalCode = "12345",
                    AddressCountry = "Sweden"
                }
            );

            modelBuilder.Entity<JobTask>().OwnsOne(jt => jt.DeliveryAddress).HasData(
                new
                {
                    JobTaskId = JobTaskId,
                    AddressStreet = "Delivery Street 2",
                    AddressCity = "Delivery City",
                    PostalCode = "67890",
                    AddressCountry = "Sweden"
                }
            );

            // Then seed the JobTask
            modelBuilder.Entity<JobTask>().HasData(
                new JobTask
                {
                    Id = JobTaskId,
                    Title = "Delivery Task",
                    Description = "Test delivery task",
                    Status = JobTaskStatus.Success,
                    IsCompleted = false,
                    StartTime = now,
                    EndTime = now.AddHours(2),
                    FK_StaffMemberId = "1STAFFM",
                    FK_JobId = JobId,
                    FK_VehicleId = VehicleId,
                    FK_FileLink = FileLinkId,
                    CreatedAt = now,
                    UpdatedAt = now,
                    FK_TenantId = CompanyTenantId
                }
            );
        }
    }
}
