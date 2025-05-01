using HardwaveStockManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwaveStockManagement.DataManagement
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = OrderDataBase");
        }
    }
}
