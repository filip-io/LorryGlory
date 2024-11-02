using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models.Staff
{
    internal class StaffRelation
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Staff")]
        public Guid StaffId { get; set; }
        public Staff Staff { get; set; }
        [ForeignKey("Boss_Staff")]
        public Guid? Boss_StaffId { get; set; }
        public Staff? Boss_Staff { get; set; }
    }
}
