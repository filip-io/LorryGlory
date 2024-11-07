using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Models
{
    public class Address
    {
        // not using this now but could be used by company, client and staff
        public Guid Id { get; set; }
        public string AdressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AdressCity { get; set; }
        public string AdressCountry { get; set; }
    }
}
