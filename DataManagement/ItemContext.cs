using HardwaveStockManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace HardwaveStockManagement.DataManagement
{
    public class ItemContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }

        public DbSet<CPU> CPUs { get; set; }

        public DbSet<GraphicsCard> GraphicsCards { get; set; }

        public DbSet<Laptop> Laptops { get; set; }

        public DbSet<Memory> MemorySticks { get; set; }

        public DbSet<Models.Monitor> Monitors { get; set; }

        public DbSet<Motherboard> Motherboards { get; set; }

        public DbSet<Storage> Storages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ItemDataBase");
        }
    }
}
