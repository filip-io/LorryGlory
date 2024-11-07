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

            // Lägg till global query filter för TenantId
            modelBuilder.Entity<StaffMember>()
                .HasQueryFilter(s => s.FK_TenantId == _tenantService.TenantId);
            // och för alla andra modeller som har data som är företagets egna!!s
            
        }
    }
}
