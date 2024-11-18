using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Models.VehicleModels;
using LorryGlory.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos
{
    public class VehicleProblemDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int SeverityLevel { get; set; }

        [ForeignKey("FileLink")]
        public Guid? FK_FileLink { get; set; }
        public FileLink? FileLink { get; set; }
    }
}
