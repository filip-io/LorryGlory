using LorryGlory.Data.Services.IServices;

namespace LorryGlory.Data.Services
{
    public class TenantService : ITenantService
    {

        private Guid _currentTenantId = new Guid("1D2B0228-4D0D-4C23-8B49-01A698857709"); // Hard coded Tenant Guid for development
        public Guid TenantId => _currentTenantId;

        public event Action<Guid> OnTenantChanged;


        public Guid[] GetTenants()
        {
            // use repo return _context.Companies.Select(c => c.Id).ToArray();
            throw new NotImplementedException();
        }

        public void SetTenant(Guid tenantId)
        {
            if (_currentTenantId != tenantId)
            {
                _currentTenantId = tenantId;
                OnTenantChanged?.Invoke(tenantId);
            }
        }
    }
}
