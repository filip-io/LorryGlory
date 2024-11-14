using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class JobTaskReport
    {
        public Guid Id { get; set; }

        [ForeignKey("JobTask")]
        public Guid FK_JobTaskId { get; set; }
        public JobTask JobTask { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }

        public string? Description { get; set; }

        [ForeignKey("FileLink")]
        public Guid? FK_FileLink { get; set; }
        public FileLink? FileLink { get; set; }

        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }
        public StaffMember CreatedBy { get; set; }

        [ForeignKey("UpdatedBy")]
        public string UpdatedById { get; set; }
        public StaffMember UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
