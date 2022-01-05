using Microsoft.EntityFrameworkCore;
using Project.API.Models;

namespace Project.API.Data
{
    public class MSSQLDbContext : DbContext
    {
        public DbSet<IntroducedCoefficient> IntroducedCoefficients { get; set; }

        public MSSQLDbContext(DbContextOptions<MSSQLDbContext> options) : base(options)
        {
        }
    }
}
