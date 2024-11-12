using LorryGlory.Data.Models;
using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.JobModels.Enums;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.StaffModels.Enums;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Services.IServices;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Data
{
    public class LorryGloryDbContext : IdentityDbContext<StaffMember>
    {
        private readonly ITenantService _tenantService;

        public LorryGloryDbContext(DbContextOptions options, ITenantService tenantService)
            : base(options)
        {
            _tenantService = tenantService;
        }

        // DbSets
        public DbSet<Company> Companies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<FileLink> FileLinks { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobTask> JobTasks { get; set; }
        public DbSet<JobTaskReport> JobTaskReports { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<StaffRelation> StaffRelations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleProblem> VehicleProblems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // global query filter for Tenant
            modelBuilder.Entity<Company>()
               .HasQueryFilter(cl => cl.TenantId == _tenantService.TenantId);
            modelBuilder.Entity<Client>()
                .HasQueryFilter(cl => cl.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<FileLink>()
                .HasQueryFilter(fl => fl.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<Job>()
                .HasQueryFilter(j => j.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<JobTask>()
                .HasQueryFilter(jt => jt.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<JobTaskReport>()
                .HasQueryFilter(jt => jt.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<StaffMember>()
                .HasQueryFilter(sm => sm.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<StaffRelation>()
                .HasQueryFilter(sr => sr.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<Vehicle>()
                .HasQueryFilter(v => v.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<VehicleProblem>()
                .HasQueryFilter(vp => vp.FK_TenantId == _tenantService.TenantId);

            // Define value object relations
            modelBuilder.Entity<Client>().OwnsOne(cl => cl.Address);
            modelBuilder.Entity<Company>().OwnsOne(co => co.Address);
            modelBuilder.Entity<StaffMember>().OwnsOne(sm => sm.Address);
            modelBuilder.Entity<Job>().OwnsOne(j => j.ContactPerson);
            modelBuilder.Entity<JobTask>(entity =>
            {
                entity.OwnsOne(jt => jt.PickupAddress);
                entity.OwnsOne(jt => jt.DeliveryAddress);
                entity.OwnsOne(jt => jt.ContactPerson);
                //entity.OwnsOne(jt => jt.JobTaskReport);
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.OwnsOne(v => v.Status);
                entity.OwnsOne(v => v.Inspection);
                entity.OwnsOne(v => v.TechnicalData, td =>
                {
                    td.OwnsOne(t => t.Category);
                });
                entity.OwnsOne(v => v.Eco);
            });


            //// if Client is delete, Tenant (company) is not affected
            //modelBuilder.Entity<Client>()
            //    .HasOne(s => s.Company)
            //    .WithMany(c => c.Clients)
            //    .HasForeignKey(s => s.FK_TenantId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, Job is not affected
            modelBuilder.Entity<Job>()
               .HasOne(j => j.Company)
               .WithMany(c => c.Jobs)
               .HasForeignKey(j => j.FK_TenantId)
               .OnDelete(DeleteBehavior.NoAction);

            // if Client is deleted, FK to Client in Job is set to null
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Client)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.FK_ClientId)
                .OnDelete(DeleteBehavior.SetNull);

            // if Company is deleted, JobTask is not affected
            modelBuilder.Entity<JobTask>()
               .HasOne(j => j.Company)
               .WithMany(c => c.JobTasks)
               .HasForeignKey(j => j.FK_TenantId)
               .OnDelete(DeleteBehavior.NoAction);

            // if StaffMember is deleted, JobTask is not affected
            //modelBuilder.Entity<JobTask>()
            //   .HasOne(j => j.StaffMember)
            //   .WithMany(c => c.JobTasks)
            //   .HasForeignKey(j => j.FK_StaffMemberId)
            //   .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, JobTaskReport is not affected
            modelBuilder.Entity<JobTaskReport>()
                  .HasOne(j => j.Company)
                  .WithMany(c => c.JobTaskReports)
                  .HasForeignKey(j => j.FK_TenantId)
                  .OnDelete(DeleteBehavior.NoAction);

            // if StaffMember is deleted, JobTaskReport is not affected (with CreatedBy)
            modelBuilder.Entity<JobTaskReport>()
               .HasOne(j => j.CreatedBy)
               .WithMany(c => c.JobTaskReports)
               .HasForeignKey(j => j.FK_CreatedById)
                  .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, StaffMember is not affected
            //modelBuilder.Entity<StaffMember>()
            //    .HasOne(s => s.Company)
            //    .WithMany(c => c.StaffMembers)
            //    .HasForeignKey(s => s.FK_TenantId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, StarrRelation is not affected
            modelBuilder.Entity<StaffRelation>()
                .HasOne(s => s.Company)
                .WithMany(c => c.StaffRelations)
                .HasForeignKey(s => s.FK_TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            //// if Company is deleted, Vehicle is not affected
            //modelBuilder.Entity<Vehicle>()
            //    .HasOne(j => j.Company)
            //    .WithMany(c => c.Vehicles)
            //    .HasForeignKey(j => j.FK_TenantId)
            //    .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, VehicleProblem is not affected
            modelBuilder.Entity<VehicleProblem>()
                .HasOne(j => j.Company)
                .WithMany(c => c.VehicleProblems)
                .HasForeignKey(j => j.FK_TenantId)
                .OnDelete(DeleteBehavior.NoAction);

            // if Company is deleted, FileLink is not affected
            //modelBuilder.Entity<FileLink>()
            //    .HasOne(j => j.Company)
            //    .WithMany(c => c.FileLinks)
            //    .HasForeignKey(j => j.FK_TenantId)
            //    .OnDelete(DeleteBehavior.NoAction);


            // Seeding
            modelBuilder.Entity<Company>().HasData(
               new Company { TenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709"), CompanyName = "Lorry Glory AB", OrganizationNumber = "11-111", PhoneNumber = "0761" },
               new Company { TenantId = new Guid("2D2B0228-4D0D-4C23-8B49-01A698857709"), CompanyName = "Chas Academy of Stök", OrganizationNumber = "22-22", PhoneNumber = "0762" }
               );
            modelBuilder.Entity<StaffMember>().HasData(
              new StaffMember { Id = "1STAFFM", JobTitle = JobTitle.Driver, FirstName = "Magda", LastName = "Kubien", PersonalNumber = "YYYYMMDD-0000", PreferredLanguage = "PL", FK_TenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709"), Email = "magda@m.m" , UserName="magda@m.m"},
              new StaffMember { Id = "2STAFFM", JobTitle = JobTitle.Boss, FirstName = "Aldor", LastName = "B", PersonalNumber = "YYYYMMDD-0000", PreferredLanguage = "PL", FK_TenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709"), Email = "aldor@b.c" , UserName="aldor@b.c"}
              );
            modelBuilder.Entity<StaffMember>().OwnsOne(sm => sm.Address).HasData(
              new { StaffMemberId= "1STAFFM", AddressCity = "Kato", PostalCode = "44444", AddressCountry = "PL", AddressStreet = "Vägen till ingenstans" },
              new { StaffMemberId = "2STAFFM", AddressCity = "Timrå", PostalCode = "33333", AddressCountry = "SE", AddressStreet = "Vägen i ingenstans" }
              );
            modelBuilder.Entity<Job>().HasData(
              new Job { Id = new Guid("1A2B0228-4D0D-4C23-8B49-01A698857709"), IsCompleted = false, Description = "Oh yea", FK_TenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709") }
              );
            modelBuilder.Entity<JobTask>().HasData(
             new JobTask{
                 FK_JobId=new Guid("1A2B0228-4D0D-4C23-8B49-01A698857709"),
                 Id = new Guid("9A2B0228-4D0D-4C23-8B49-01A698857709"), 
                 IsCompleted = false, 
                 Description = "Oh yea", 
                 Title="Oh",
                 StartTime=DateTime.Now,
                 EndTime = DateTime.Now,
                 CreatedAt=DateTime.Now,
                 FK_StaffMemberId = "1STAFFM",
                 FK_TenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709") }
             );

        }
    }
}
