using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.JobModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerPhoneNr { get; set; }

        [ForeignKey("Customer")]
        public Guid FK_CustomerId { get; set; }
        public Client.Client Customer { get; set; }

    }
}
