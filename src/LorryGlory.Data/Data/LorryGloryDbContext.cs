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
    public class LorryGloryDbContext : IdentityDbContext
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
        public DbSet<FileLink> FileLinks{ get; set; }
        public DbSet<Job> Jobs{ get; set; }
        public DbSet<JobTask> JobTasks{ get; set; }
        public DbSet<TaskReport> TaskReports{ get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<StaffRelation> StaffRelations { get; set; }
        public DbSet<Vehicle> Vehicles{ get; set; }
        //inte säker varför vi skulle skapa DbSets för bilens egenskaper


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Adds global query filter for Tenant in all tables
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
            modelBuilder.Entity<TaskReport>()
                .HasQueryFilter(tr => tr.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<StaffMember>()
                .HasQueryFilter(sm => sm.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<StaffRelation>()
                .HasQueryFilter(sr => sr.FK_TenantId == _tenantService.TenantId);
            modelBuilder.Entity<Vehicle>()
                .HasQueryFilter(v => v.FK_TenantId == _tenantService.TenantId);

            // Define Address relation
            modelBuilder.Entity<Client>().OwnsOne(cl => cl.Address);
            modelBuilder.Entity<Company>().OwnsOne(co => co.Address);
            modelBuilder.Entity<StaffMember>().OwnsOne(sm => sm.Address);
            modelBuilder.Entity<JobTask>(entity =>
            {
                entity.OwnsOne(jt => jt.PickupAddress);
                entity.OwnsOne(jt => jt.DeliveryAddress);
            });
        }
    }
}
