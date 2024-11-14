using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Data.Models.Vehicle
{
    public class EcoDetails
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 3)]
        public string EuroClass { get; set; }
    }
}
