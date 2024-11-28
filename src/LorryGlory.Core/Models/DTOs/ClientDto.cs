using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LorryGlory.Core.Models.DTOs
{
    public class ClientDto
    {
        public Guid Id { get; set; }
        public string ClientName { get; set; }
        public string? OrganizationNumber { get; set; }
        public string? PersonalNumber { get; set; }
        public string PhoneNumber { get; set; }
        public AddressDto Address { get; set; }
        //public ICollection<JobDto>? Jobs { get; set; }
        public Guid FK_TenantId { get; set; }
        public string CompanyName { get; set; }
    }

    public class ClientCreateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string ClientName { get; set; }

        [StringLength(20)]
        public string? OrganizationNumber { get; set; }

        [StringLength(20)]
        public string? PersonalNumber { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public AddressCreateUpdateDto Address { get; set; }
    }

    public class ClientUpdateDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string ClientName { get; set; }

        [StringLength(20)]
        public string? OrganizationNumber { get; set; }

        [StringLength(20)]
        public string? PersonalNumber { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public AddressCreateUpdateDto Address { get; set; }
    }
}