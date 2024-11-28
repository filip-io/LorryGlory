using LorryGlory.Data.Data;
using LorryGlory.Data.Models.ClientModels;
using LorryGlory.Data.Models.JobModels;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LorryGlory.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(LorryGloryDbContext context, ILogger<ClientRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Client> CreateAsync(Client client)
        {
            var result = await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<IEnumerable<Client?>> GetAllAsync()
        {
            return await _context.Clients
            .Include(c => c.Address)
            .Include(c => c.Jobs)
            .Include(c => c.Company)
            .ToListAsync();
        }
    }
}
