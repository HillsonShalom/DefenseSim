using DefenseSim.ModelsDefense;
using Microsoft.EntityFrameworkCore;

namespace DefenseSim.Data
{
    public class DefenseDbContext : DbContext
    {
        public DefenseDbContext(DbContextOptions<DefenseDbContext> options) : base(options) { }

        public DbSet<ResponseD> Responses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
    }
}
