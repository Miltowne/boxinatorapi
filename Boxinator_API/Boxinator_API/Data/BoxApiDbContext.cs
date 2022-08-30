using Boxinator_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Boxinator_API.Data
{
    public class BoxApiDbContext : DbContext
    {
        public BoxApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public BoxApiDbContext()
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Multiplier> Multipliers { get; set; }
    }
}
