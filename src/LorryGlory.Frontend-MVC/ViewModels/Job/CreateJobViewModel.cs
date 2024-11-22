using System.ComponentModel.DataAnnotations;

namespace LorryGlory_Frontend_MVC.ViewModels.Job
{
    public class CreateJobViewModel
    {
        //public JobStatus? Status { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ClientViewModel? Client { get; set; }
        public ContactPersonViewModel? ContactPerson { get; set; }
        public Guid? FK_FileLink { get; set; }
    }

    public class ClientViewModel
    {
        public string ClientName { get; set; }
        public string? OrganizationNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public AddressViewModel Address { get; set; }
    }

    public class AddressViewModel
    {
        public string AddressStreet { get; set; }
        public string PostalCode { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
    }

    public class ContactPersonViewModel
    {
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
