using LorryGlory.Data.Models.StaffModels;
using LorryGlory.Data.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace LorryGlory.Data.Services
{
    public class TenantService : ITenantService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        private Guid _currentTenantId;
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

        public bool IsSuperAdmin()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.IsInRole("SuperAdmin") ?? false;
        }
    }
}
