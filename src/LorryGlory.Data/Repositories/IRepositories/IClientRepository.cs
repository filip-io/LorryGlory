using LorryGlory.Data.Models.ClientModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories.IRepositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client?>> GetAllAsync();
    }
}
