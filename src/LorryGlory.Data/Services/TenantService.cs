using LorryGlory.Data.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Services
{
    internal class TenantService : ITenantService
    {
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
    }
}
