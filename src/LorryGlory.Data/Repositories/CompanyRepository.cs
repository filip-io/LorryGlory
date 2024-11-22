using LorryGlory.Data.Data;
using LorryGlory.Data.Models.CompanyModels;
using LorryGlory.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LorryGlory.Data.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly LorryGloryDbContext _context;
        private readonly ILogger<CompanyRepository> _logger;

        public CompanyRepository(LorryGloryDbContext context, ILogger<CompanyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Company?>> GetAllAsync()
        {
            return await _context.Companies
             .Include(c => c.Clients)
             .Include(c => c.Jobs)
             .Include(c => c.StaffMembers)
             .Include(c => c.Vehicles)
             .ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(Guid id)
        {
            return await _context.Companies
             .Include(c => c.Clients)
             .Include(c => c.Jobs)
             .Include(c => c.StaffMembers)
             .Include(c => c.Vehicles)
             .SingleOrDefaultAsync(c => c.TenantId == id);
        }

        public async Task<Company?> GetByOrganizationNumberAsync(string organizationNumber)
        {
            return await _context.Companies
            .Include(c => c.Clients)
            .Include(c => c.Jobs)
            .Include(c => c.StaffMembers)
            .Include(c => c.Vehicles)
            .SingleOrDefaultAsync(c => c.OrganizationNumber == organizationNumber);
        }

        public async Task<Company> CreateAsync(Company company)
        {
            var result = await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"New company with id {result.Entity.TenantId} created at {DateTime.Now}.");
            return result.Entity;
        }
        public async Task<Company?> UpdateAsync(Company company)
        {
            _logger.LogInformation($"Attempt to update company with id {company.TenantId} at {DateTime.Now}.");
            throw new NotImplementedException();
        }
        public async Task<Company?> DeleteAsync(Company company)
        {
            _logger.LogInformation($"Attempt to delete company with id {company.TenantId} at {DateTime.Now}.");
            throw new NotImplementedException();
        }

    }
}
