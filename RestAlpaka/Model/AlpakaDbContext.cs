using Microsoft.EntityFrameworkCore;

namespace RestAlpaka.Model
{
    public class AlpakaDbContext : DbContext
    {
        public AlpakaDbContext(DbContextOptions<AlpakaDbContext> options) : base(options)
        {
        }

        public DbSet<Alpaka> Alpakas { get; set; }
    }
}
