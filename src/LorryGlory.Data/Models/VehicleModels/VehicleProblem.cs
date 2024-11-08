using LorryGlory.Data.Models.CompanyModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models.VehicleModels
{
    public class VehicleProblem
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeverityLevel { get; set; }
        public FileLink? FileLink { get; set; }

        [ForeignKey("Vehicle")]
        public Guid FK_VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }


        [ForeignKey("Company")]
        public Guid FK_TenantId { get; set; }
        public Company Company { get; set; }
    }
}
