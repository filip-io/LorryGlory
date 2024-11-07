using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.JobModels.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class Job
    {
        // customer name email phone gruppera till contact list på customer?
        public Guid Id { get; set; }
        public JobStatus Status { get; set; }
        public string Description { get; set; }

        public TimeSpan? EstimatedTotalTime { get; set; }
        public TimeSpan? ActualTotalTime { get; set; }

        public string? ClientName { get; set; }
        public string? ClientEmail { get; set; }
        public string? ClientPhoneNr { get; set; }

        [ForeignKey("Client")]
        public Guid FK_ClientId { get; set; }
        public Client Client{ get; set; }

        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }

    }
}
