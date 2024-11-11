using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class JobTask
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }
        public bool IsCompleted { get; set; }

        public ContactPerson? ContactPerson { get; set; }
        public Address PickupAddress { get; set; }
        public Address DeliveryAddress { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        [ForeignKey("StaffMember")]
        public string FK_StaffMemberId { get; set; }
        public StaffMember StaffMember { get; set; }


        [ForeignKey("Job")]
        public Guid FK_JobId { get; set; }
        public Job Job { get; set; }


        [ForeignKey("Vehicle")]
        public Guid? FK_VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


        [ForeignKey("FileLink")]
        public Guid? FK_FileLink { get; set; }
        public FileLink FileLink { get; set; }


        public JobTaskReport JobTaskReport { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
