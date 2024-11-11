using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Models.VehicleModels;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Data.Models.CompanyModels
{
    public class Company
    {
        [Key]
        public Guid TenantId { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address? Address { get; set; }
       // public FileLink? FileLink { get; set; }

        public ICollection<Client>? Clients { get; set; }
        public ICollection<Job>? Jobs { get; set; }
        public ICollection<JobTask>? JobTasks { get; set; }
        public ICollection<JobTaskReport>? JobTaskReports { get; set; }
        public ICollection<StaffMember>? StaffMembers { get; set; }
        public ICollection<StaffRelation>? StaffRelations { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }
        public ICollection<VehicleProblem>? VehicleProblems { get; set; }
        public ICollection<FileLink>? FileLinks { get; set; }

    }
}
