using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs.VehicleDtos.VehicleDetailsDtos
{
    public class InspectionDto
    {
        public DateOnly LatestInspection { get; set; }
        public DateOnly InspectionValidUntil { get; set; }
        public int Meter { get; set; } // mätarställning - parsa siffran, kommer som "xxx mil", räkna om till km
    }
}
