using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
