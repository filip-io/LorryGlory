using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class JobTask
    {
        // Task Done? planned time object med 2 fält?
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
        public Guid FK_StaffMemberId { get; set; }
        public StaffMember StaffMember { get; set; }

        [ForeignKey("Job")]
        public Guid FK_JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("Vehicle")]
        public Guid FK_VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public FileLink? FileLink { get; set; }
        public JobTaskReport JobTaskReport { get; set; }

        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }

    }
    public class JobTaskReport
    {
        public DateTime ReportedStartTime { get; set; }
        public DateTime ReportedEndTime { get; set; }
        public string Note { get; set; }

        public DateTime CreatedAt { get; set; }
        public StaffMember CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public StaffMember UpdatedBy { get; set; }

        public FileLink? FileLink { get; set; }
    }

}
