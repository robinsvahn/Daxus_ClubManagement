using Microsoft.EntityFrameworkCore;

namespace Daxus_FootballManagement.DAL.DbContext
{
    public class DaxusContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DaxusContext(DbContextOptions<DaxusContext> options)
            : base(options)
        {
        }

        public DbSet<Model.Guest> Guests { get; set; }
        public DbSet<Model.Player> Players { get; set; }
    }
}
