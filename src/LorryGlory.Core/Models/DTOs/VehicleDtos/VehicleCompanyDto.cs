using LorryGlory.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    // Probably change this to CompanyDto and reuse from there.
    public class VehicleCompanyDto
    {
        public string CompanyName { get; set; }
        public string OrganizationNumber { get; set; }
        public string? PhoneNumber { get; set; }

        public Address? Address { get; set; }
        // public FileLink? FileLink { get; set; }
    }
}
