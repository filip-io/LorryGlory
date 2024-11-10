using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models.JobModels
{
    public class JobTaskReport
    {
        public Guid Id { get; set; }
        public DateTime ReportedStartTime { get; set; }
        public DateTime ReportedEndTime { get; set; }
        public string Note { get; set; }


        public DateTime CreatedAt { get; set; }
        [ForeignKey("CreatedBy")]
        public string? FK_CreatedById { get; set; }
        public StaffMember CreatedBy { get; set; }
        
        public DateTime? UpdatedAt { get; set; }
        [ForeignKey("UpdatedBy")]
        public string? FK_UpdatedById { get; set; }
        public StaffMember UpdatedBy { get; set; }

        
        [ForeignKey("FileLink")]
        public Guid? FK_FileLink { get; set; }
        public FileLink FileLink { get; set; }

        [ForeignKey("JobTask")]
        public Guid FK_JobTaskId { get; set; }
        public JobTask JobTask { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
