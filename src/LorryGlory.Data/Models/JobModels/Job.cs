using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public JobStatus? Status { get; set; }
        public bool IsCompleted { get; set; }


        public TimeSpan? EstimatedTotalTime { get; set; }
        public TimeSpan? ActualTotalTime { get; set; }


        [ForeignKey("Client")]
        public Guid? FK_ClientId { get; set; }
        public Client? Client { get; set; }
        public ContactPerson? ContactPerson { get; set; }

        public virtual ICollection<JobTask>? JobTasks { get; set; }

        [ForeignKey("FileLink")]
        public Guid? FK_FileLink { get; set; }
        public FileLink FileLink { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }

    }
}