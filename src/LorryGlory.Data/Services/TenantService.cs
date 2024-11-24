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

        public void SetTenant(Guid? tenantId)
        {
            Console.WriteLine($"TenantService instance: {this.GetHashCode()}");
            if (tenantId.HasValue)
            {
                if (_currentTenantId != tenantId.Value)
                {
                    Console.WriteLine("Before _currentTenantId: Tenant ID set to: " + _currentTenantId);
                    _currentTenantId = tenantId.Value;
                    Console.WriteLine("After _currentTenantId: Tenant ID set to: " + _currentTenantId);
                    Console.WriteLine("After TenantId: Tenant ID set to: " + TenantId);
                    OnTenantChanged?.Invoke(_currentTenantId);
                }
            }
            else
            {
                _currentTenantId = Guid.Empty;
                Console.WriteLine("Tenant ID reset to empty.");
                OnTenantChanged?.Invoke(_currentTenantId);
            }
        }

        public bool IsSuperAdmin()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.IsInRole("SuperAdmin") ?? false;
        }

    }
}
