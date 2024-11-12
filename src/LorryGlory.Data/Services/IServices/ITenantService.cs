namespace LorryGlory.Data.Services.IServices
{
    public interface ITenantService
    {
        Guid TenantId { get; }

        void SetTenant(Guid tenantId);

        Guid[] GetTenants();

        event Action<Guid> OnTenantChanged;
    }
}
