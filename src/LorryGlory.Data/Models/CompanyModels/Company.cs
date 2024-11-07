using LorryGlory.Data.Models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models.CompanyModels
{
    public class Company
    {
        // Owner = ?
        // LogoLink or relation to File-model?
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public string LogoLink { get; set; }

        public virtual List<StaffMember>? StaffMembers { get; set; }
    }
}
