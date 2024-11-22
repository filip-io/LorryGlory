namespace LorryGlory.Core.Models.DTOs
{
    public class StaffMemberRolesDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid FK_TenantId { get; set; }
        public ICollection<string>? Roles { get; set; }
    }
    public class StaffMemberAddRoleNameDto
    {
        public string RoleName { get; set; }
    }
}
