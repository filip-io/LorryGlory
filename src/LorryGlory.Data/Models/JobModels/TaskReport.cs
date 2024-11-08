using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class TaskReport
    {

        // ska den ha Status?
        public Guid Id { get; set; }

        [ForeignKey("JobTask")]
        public Guid FK_JobTask { get; set; }
        public JobTask JobTask { get; set; }

        public DateTime ReportedStartTime { get; set; }
        public DateTime ReportedEndTime { get; set; }
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; }
        public StaffMember CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StaffMember UpdatedBy { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
