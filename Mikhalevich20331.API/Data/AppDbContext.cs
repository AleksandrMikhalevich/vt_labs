using Microsoft.EntityFrameworkCore;
using Mikhalevich20331.ZooshopDomain.Entities;

namespace Mikhalevich20331.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
