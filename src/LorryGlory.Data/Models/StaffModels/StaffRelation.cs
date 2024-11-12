using LorryGlory.Data.Models.CompanyModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.StaffModels
{
    public class StaffRelation
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Staff")]
        public string StaffId { get; set; }
        public StaffMember Staff { get; set; }
        [ForeignKey("Boss_Staff")]
        public string? Boss_StaffId { get; set; }
        public StaffMember? Boss_Staff { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
