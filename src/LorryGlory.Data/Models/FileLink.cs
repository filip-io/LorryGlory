using LorryGlory.Data.Models.CompanyModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models
{
    public enum FileLinkType
    {
        Job,
        JobTask,
        JobTaskReport,
        VehicleProblem
    }
    public class FileLink
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(2048)]
        public string UriLink { get; set; } = string.Empty;

        [Required]
        public Guid LinkedEntityId { get; set; }
        public FileLinkType LinkedEntityType { get; set; }

        [Required]
        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; } = null!; // C# warning suppressed, but relationship is still enforced by EF Core/database
    }
}