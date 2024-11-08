using LorryGlory.Data.Models.CompanyModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models
{
    public enum FileLinkType
    {
        Company,
        Job,
        JobTask,
        VehicleProblem
    }
    public class FileLink
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string UriLink { get; set; }

        public Guid LinkedEntityId { get; set; }
        public FileLinkType LinkedEntityType { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
