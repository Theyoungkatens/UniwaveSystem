using UniwaveSystem.Models;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Models;
namespace UniwaveSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Blog> Blogs { get; set; }
            public DbSet<Contact> Contacts { get; set; }
        public DbSet<LogisticRoute> LogisticRoutes { get; set; }
        public DbSet<ShippingOrder> ShippingOrders { get; set; }



    }
}
