using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Data.Models.JobModels
{
    public class JobTaskReport
    {
        [Key]
        public Guid Id { get; set; }
        public Guid FK_JobTaskId { get; set; }
        public Guid FK_TenantId { get; set; }
        public string? Description { get; set; }
        public Guid? FK_FileLink { get; set; }
        public string CreatedById { get; set; }
        public string? UpdatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        // Navigation properties
        public Company Company { get; set; }
        public JobTask JobTask { get; set; }
        public StaffMember CreatedBy { get; set; }
        public StaffMember UpdatedBy { get; set; }
        public FileLink? FileLink { get; set; }
    }
}
