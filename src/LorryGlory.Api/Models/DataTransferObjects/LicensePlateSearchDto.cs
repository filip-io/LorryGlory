using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Api.Models.DataTransferObjects
{
    public class LicensePlateSearchDto
    {
        [Required]
        public string RegNo { get; set; }
    }
}
