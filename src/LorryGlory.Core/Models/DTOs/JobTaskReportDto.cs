using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs
{
    public class JobTaskReportDto
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public FileLinkDto? FileLink { get; set; }
        public StaffMemberDto CreatedBy { get; set; }
        public StaffMemberDto UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
