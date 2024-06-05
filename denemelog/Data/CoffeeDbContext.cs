using Microsoft.EntityFrameworkCore;
using denemelog.Models;

namespace denemelog.Data
{
    public class CoffeeDbContext : DbContext
    {
        public CoffeeDbContext(DbContextOptions<CoffeeDbContext> options)
            : base(options)
        {
        }

        public DbSet<Coffee> Coffees { get; set; }
    }
}