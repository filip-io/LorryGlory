using System.ComponentModel.DataAnnotations;

namespace LorryGloryMockApi.Data.Models.Vehicle
{
    public class EcoDetails
    {
        public int Id { get; set; }
        [StringLength(maximumLength: 3)]
        public string EuroClass { get; set; }
    }
}
