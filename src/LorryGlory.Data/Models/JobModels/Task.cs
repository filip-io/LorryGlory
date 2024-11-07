using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class Task
    {
        // type eller title? Task Done? planned time object med 2 fält?
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TaskStatus Status { get; set; }

        public string PickupAdressStreet { get; set; }
        public string PickupPostalCode { get; set; }
        public string PickupAdressCity { get; set; }
        public string PickupAdressCountry { get; set; }

        public string DeliveryAdressStreet { get; set; }
        public string DeliveryPostalCode { get; set; }
        public string DeliveryAdressCity { get; set; }
        public string DeliveryAdressCountry { get; set; }

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

        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
