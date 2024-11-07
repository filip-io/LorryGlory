using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LorryGlory.Data.Models.StaffModels
{
    public class StaffRelation
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public StaffMember Staff { get; set; }
        [ForeignKey("Boss_Staff")]
        public Guid? Boss_StaffId { get; set; }
        public StaffMember? Boss_Staff { get; set; }
    }
}
