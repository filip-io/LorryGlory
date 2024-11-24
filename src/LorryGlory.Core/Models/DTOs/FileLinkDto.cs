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
        public string? Name { get; set; }
        public string UriLink { get; set; }
    }
}
