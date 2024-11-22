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

        public Guid TenantId
        {
            get
            {
                var user = _httpContextAccessor.HttpContext?.User;
                var userTenantId = user?.Claims?.SingleOrDefault(uc => uc.Type == "TenantId")?.Value;
                return !string.IsNullOrEmpty(userTenantId) ? new Guid(userTenantId) : Guid.Empty;
            }
        }

        public bool IsSuperAdmin()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            return user?.IsInRole("SuperAdmin") ?? false;
        }
    }
}
