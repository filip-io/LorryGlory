using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.JobModels
{
    public class File
    {
        // tänkte att vi kanske ville kalla filer för nåt?
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string UriLink { get; set; }

        [ForeignKey("Job")]
        public Guid? FK_JobId { get; set; }
        public Job Job { get; set; }

        [ForeignKey("Task")]
        public Guid? TaskId { get; set; }
        public Task Task { get; set; }

    }
}
