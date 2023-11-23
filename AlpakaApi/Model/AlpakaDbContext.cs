using Microsoft.EntityFrameworkCore;

namespace AlpakaApi.Model
{
    public class AlpakaDbContext : DbContext
    {
        
        
            public AlpakaDbContext(DbContextOptions<AlpakaDbContext> options) : base(options)
            {

            }

            public DbSet<Alpakas> Alpakas { get; set; }
        
    }
}
