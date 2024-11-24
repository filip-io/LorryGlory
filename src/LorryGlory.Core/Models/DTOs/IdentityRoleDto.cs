namespace LorryGlory.Core.Models.DTOs
{
    public class IdentityRoleDto
    {
        public virtual Guid Id { get; set; } 
        public virtual string? Name { get; set; }
        public virtual string? NormalizedName { get; set; }
    }
    public class IdentityRoleCreateDto
    {
        public virtual string? Name { get; set; }
    }
    public class IdentityRoleUpdateDto 
    { 
        public virtual Guid Id { get; set; }
        public virtual string? Name { get; set; }
    }
}
