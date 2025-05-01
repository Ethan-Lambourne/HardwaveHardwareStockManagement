using HardwaveStockManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace HardwaveStockManagement.DataManagement
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = UserDataBase");
        }
    }
}
