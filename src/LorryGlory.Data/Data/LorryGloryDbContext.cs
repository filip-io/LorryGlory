using LorryGlory.Data.Data.Seeding;
using LorryGlory.Data.Models;
using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Data
{
    public class LorryGloryDbContext : IdentityDbContext<StaffMember>
    {
        private readonly ITenantService _tenantService;

        public LorryGloryDbContext(DbContextOptions<LorryGloryDbContext> options, ITenantService tenantService)
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


            // Load entity configs
            ConfigureCompany(modelBuilder);
            ConfigureClient(modelBuilder);
            ConfigureFileLink(modelBuilder);
            ConfigureJob(modelBuilder);
            ConfigureJobTask(modelBuilder);
            ConfigureJobTaskReport(modelBuilder);
            ConfigureStaffMember(modelBuilder);
            ConfigureStaffRelation(modelBuilder);
            ConfigureVehicle(modelBuilder);
            ConfigureVehicleProblem(modelBuilder);


            // Populate seed data
            modelBuilder.SeedData();
        }

        private void ConfigureCompany(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                // Key and filter
                entity.HasKey(e => e.TenantId);
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.TenantId == _tenantService.TenantId);

                // Value objects
                entity.OwnsOne(e => e.Address);

                // Relationships
                entity.HasMany(e => e.Clients)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Jobs)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.JobTasks)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.JobTaskReports)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.StaffMembers)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.StaffRelations)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Vehicles)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.VehicleProblems)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.FileLinks)
                    .WithOne(e => e.Company)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureClient(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);
                entity.OwnsOne(e => e.Address);

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Clients)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureFileLink(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FileLink>(entity =>
            {
                // Primary key
                entity.HasKey(e => e.Id);

                // Query filter for multi-tenancy
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Required fields
                entity.Property(e => e.UriLink).IsRequired();
                entity.Property(e => e.LinkedEntityId).IsRequired();
                entity.Property(e => e.LinkedEntityType).IsRequired();
                entity.Property(e => e.FK_TenantId).IsRequired();

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.FileLinks)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure enum as string (optional)
                entity.Property(e => e.LinkedEntityType)
                    .HasConversion<string>();

                // Add index for faster lookups, compound index unique per tenant to prevent duplicates
                entity.HasIndex(e => new { e.FK_TenantId, e.LinkedEntityType, e.LinkedEntityId })
                    .IsUnique();
            });
        }

        private void ConfigureJob(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);
                entity.OwnsOne(e => e.ContactPerson);

                entity.HasOne(e => e.Company)
                    .WithMany(c => c.Jobs)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Client)
                    .WithMany(c => c.Jobs)
                    .HasForeignKey(e => e.FK_ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureJobTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTask>(entity =>
            {
                // Query filter
                //entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Value objects (owned entities)
                entity.OwnsOne(e => e.PickupAddress);
                entity.OwnsOne(e => e.DeliveryAddress);
                entity.OwnsOne(e => e.ContactPerson);

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.JobTasks)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                // StaffMember relationship (bidirectional because StaffMember has JobTasks collection)
                entity.HasOne(e => e.StaffMember)
                    .WithMany(sm => sm.JobTasks)
                    .HasForeignKey(e => e.FK_StaffMemberId)
                    .OnDelete(DeleteBehavior.Restrict);

                // One-to-one relationship with JobTaskReport
                entity.HasOne(e => e.JobTaskReport)
                    .WithOne(r => r.JobTask)
                    .HasForeignKey<JobTaskReport>(r => r.FK_JobTaskId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Vehicle relationship
                entity.HasOne(e => e.Vehicle)           // JobTask Entity: "I have one Vehicle property"
                    .WithMany()                         // Vehicle Entity: "I can be referenced by many JobTasks (but I don't track them)"
                    .HasForeignKey(e => e.FK_VehicleId) // JobTask Entity: "I use FK_VehicleId to reference my Vehicle"
                    .OnDelete(DeleteBehavior.SetNull)   // JobTask Entity: "If my Vehicle is deleted, set my FK_VehicleId to null"
                    .IsRequired(false);                 // JobTask Entity: "My Vehicle/FK_VehicleId can be null"

                // Default values for CreatedAt and UpdatedAt
                //entity.Property(e => e.CreatedAt)
                //    .HasDefaultValueSql("GETDATE()")
                //    .ValueGeneratedOnAdd();

                //entity.Property(e => e.UpdatedAt)
                //    .ValueGeneratedOnAddOrUpdate();
            });
        }

        private void ConfigureJobTaskReport(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobTaskReport>(entity =>
            {
                // Primary key and query filter
                entity.HasKey(e => e.Id);
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Required fields
                entity.Property(e => e.FK_JobTaskId).IsRequired();
                entity.Property(e => e.FK_TenantId).IsRequired();
                entity.Property(e => e.CreatedById).IsRequired();
                entity.Property(e => e.UpdatedById).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.UpdatedAt).IsRequired();

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.JobTaskReports)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Audit relationships
                entity.HasOne(e => e.CreatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(e => e.UpdatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                // JobTask relationship (one-to-one)
                entity.HasOne(e => e.JobTask)
                    .WithOne(jt => jt.JobTaskReport)
                    .HasForeignKey<JobTaskReport>(e => e.FK_JobTaskId)
                    .OnDelete(DeleteBehavior.Cascade);

                // FileLink relationship (optional)
                entity.HasOne(e => e.FileLink)
                    .WithMany()
                    .HasForeignKey(e => e.FK_FileLink)
                    .OnDelete(DeleteBehavior.Restrict);

                // Default values for CreatedAt and UpdatedAt
                //entity.Property(e => e.CreatedAt)
                //    .HasDefaultValueSql("GETDATE()")
                //    .ValueGeneratedOnAdd();

                //entity.Property(e => e.UpdatedAt)
                //    .ValueGeneratedOnAddOrUpdate();
            });
        }

        private void ConfigureStaffMember(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffMember>(entity =>
            {

                // Query filter here would not allow login
                //entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Value objects
                entity.OwnsOne(e => e.Address);

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.StaffMembers)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureStaffRelation(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffRelation>(entity =>
            {
                // Query filter
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.StaffRelations)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureVehicle(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                // Query filter
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Value objects (nested owned entities)
                entity.OwnsOne(e => e.Status);
                entity.OwnsOne(e => e.Inspection);
                entity.OwnsOne(e => e.TechnicalData);
                entity.OwnsOne(e => e.Eco);

                // Company relationship
                //entity.HasOne(e => e.Company)
                //    .WithMany(c => c.Vehicles)
                //    .HasForeignKey(e => e.FK_TenantId)
                //    .OnDelete(DeleteBehavior.Restrict);
            });
        }

        private void ConfigureVehicleProblem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleProblem>(entity =>
            {
                // Query filter
                entity.HasQueryFilter(e => _tenantService.IsSuperAdmin() || e.FK_TenantId == _tenantService.TenantId);

                // Company relationship
                entity.HasOne(e => e.Company)
                    .WithMany(c => c.VehicleProblems)
                    .HasForeignKey(e => e.FK_TenantId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}