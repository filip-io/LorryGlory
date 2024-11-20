using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LorryGlory.Core.Models.DTOs
{
    public class AddressDto
    {
        public string AddressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }

    // For creating/updating addresses
    public class AddressCreateUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string AddressStreet { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^[0-9a-zA-Z\s-]*$", ErrorMessage = "Postal code can only contain letters, numbers, spaces, and hyphens")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCity { get; set; }

        [Required]
        [StringLength(100)]
        public string AddressCountry { get; set; }
    }
}