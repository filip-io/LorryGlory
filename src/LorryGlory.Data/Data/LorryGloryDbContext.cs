using LorryGlory.Data.Models;
using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels;
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

                // Main JobTask -> StaffMember relationship (this one is bidirectional because StaffMember has JobTasks collection)
                entity.HasOne(jt => jt.StaffMember)
                    .WithMany(sm => sm.JobTasks)
                    .HasForeignKey(jt => jt.FK_StaffMemberId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configure JobTaskReport as owned type with one-way relationships
                entity.OwnsOne(jt => jt.JobTaskReport, reportBuilder =>
                {
                    // CreatedBy relationship (one-way)
                    reportBuilder.HasOne(r => r.CreatedBy)
                        .WithMany()  // No need for navigation property back to reports
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Restrict); // PREVENT the deletion of a StaffMember if they are referenced as CreatedBy in any JobTaskReport

                    // UpdatedBy relationship (one-way)
                    reportBuilder.HasOne(r => r.UpdatedBy)
                        .WithMany()  // No need for navigation property back to reports
                        .HasForeignKey("UpdatedById")
                        .OnDelete(DeleteBehavior.Restrict); // PREVENT the deletion of a StaffMember if they are referenced as UpdatedBy in any JobTaskReport 

                    // FileLink relationship (one-way)
                    reportBuilder.HasOne(r => r.FileLink)
                        .WithMany()
                        .HasForeignKey(r => r.FK_FileLink)
                        .OnDelete(DeleteBehavior.Restrict);
                });
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



            modelBuilder.Entity<Client>()
                .HasOne(s => s.Company)
                .WithMany(c => c.Clients)
                .HasForeignKey(s => s.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict); // RESTRICT means: "Don't let me delete this Company if any Clients are still referring to it - throw an error instead"

            modelBuilder.Entity<Job>()
               .HasOne(j => j.Company)
               .WithMany(c => c.Jobs)
               .HasForeignKey(j => j.FK_TenantId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Job>()
                .HasOne(j => j.Client)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.FK_ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JobTask>()
               .HasOne(j => j.Company)
               .WithMany(c => c.JobTasks)
               .HasForeignKey(j => j.FK_TenantId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffMember>()
                .HasOne(s => s.Company)
                .WithMany(c => c.StaffMembers)
                .HasForeignKey(s => s.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StaffRelation>()
                .HasOne(s => s.Company)
                .WithMany(c => c.StaffRelations)
                .HasForeignKey(s => s.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(j => j.Company)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(j => j.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VehicleProblem>()
                .HasOne(j => j.Company)
                .WithMany(c => c.VehicleProblems)
                .HasForeignKey(j => j.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FileLink>()
                .HasOne(j => j.Company)
                .WithMany(c => c.FileLinks)
                .HasForeignKey(j => j.FK_TenantId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
