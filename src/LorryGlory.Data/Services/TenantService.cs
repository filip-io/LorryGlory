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

            //var user = _httpContextAccessor.HttpContext?.User;
            //_currentTenantId = new Guid(user?.Claims?.SingleOrDefault(uc => uc.Type == "TenantId")?.Value 
            //    ?? "71a1006f-b2bf-49e0-ad7d-4e7ac27adaf9");
        }


        private Guid _currentTenantId;
        public Guid TenantId => _currentTenantId;

        public event Action<Guid> OnTenantChanged;

        public void SetTenant()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            var userTenantId = user?.Claims?.SingleOrDefault(uc => uc.Type == "TenantId")?.Value;
            Guid? tenantId = userTenantId != null ? new Guid(userTenantId) : Guid.Empty;

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
