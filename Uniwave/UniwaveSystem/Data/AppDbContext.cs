using UniwaveSystem.Models;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Models;
namespace UniwaveSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
    }
}
