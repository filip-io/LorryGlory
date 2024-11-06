using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LorryGlory.Data.Data
{
    public class LorryGloryDbContext : IdentityDbContext
    {
        public LorryGloryDbContext(DbContextOptions options) :base(options) { }

        // DbSets


        //OnModelCreating eller sånt om vi vill
    }
}
