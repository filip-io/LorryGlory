using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Core.Models.DTOs
{
    public class FileLinkDto
    {
        public Guid Id { get; set; }
<<<<<<<< HEAD:src/LorryGlory.Core/Models/DTOs/FileLinkDto.cs
        public string? Name { get; set; }
        public string UriLink { get; set; }
========
        public string RegNo { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
>>>>>>>> main:src/LorryGlory.Core/Models/DTOs/VehicleDto.cs
    }
}
