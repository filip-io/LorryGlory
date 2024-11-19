using System;
using System.Collections.Generic;
using LorryGlory.Data.Models.JobModels.Enums;

namespace LorryGlory.Core.Models.DTOs
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public JobStatus? Status { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan? EstimatedTotalTime { get; set; }
        public TimeSpan? ActualTotalTime { get; set; }
        public Guid? FK_ClientId { get; set; }
        public ClientDto? Client { get; set; }
        public ContactPersonDto? ContactPerson { get; set; }
        public ICollection<JobTaskDto>? JobTasks { get; set; }
        public Guid? FK_FileLink { get; set; }
        public FileLinkDto? FileLink { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid FK_TenantId { get; set; }
        public string CompanyName { get; set; }
    }

    public class JobCreateDto
    {
        public JobStatus? Status { get; set; }
        public string Description { get; set; }
        public TimeSpan? EstimatedTotalTime { get; set; }
        public Guid? FK_ClientId { get; set; }
        public ContactPersonCreateUpdateDto? ContactPerson { get; set; }
        public Guid? FK_FileLink { get; set; }
    }

    public class JobUpdateDto
    {
        public Guid Id { get; set; }
        public JobStatus? Status { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TimeSpan? EstimatedTotalTime { get; set; }
        public TimeSpan? ActualTotalTime { get; set; }
        public Guid? FK_ClientId { get; set; }
        public ContactPersonCreateUpdateDto? ContactPerson { get; set; }
        public Guid? FK_FileLink { get; set; }
    }
}