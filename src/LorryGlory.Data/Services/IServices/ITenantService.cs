namespace LorryGlory.Data.Services.IServices
{
    public interface ITenantService
    {
        Guid TenantId { get; }

        void SetTenant();

        //Guid[] GetTenants();

        event Action<Guid> OnTenantChanged;

        bool IsSuperAdmin();

        //void AddTenant();
    }
}
