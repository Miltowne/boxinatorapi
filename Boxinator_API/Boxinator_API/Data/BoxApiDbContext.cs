using Boxinator_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Boxinator_API.Data
{
    public class BoxApiDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<GuestUser> GuestUsers { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Multiplier> Multipliers { get; set; }
        
        public BoxApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public BoxApiDbContext()
        {
        }


        // Seed data for the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Shipments)
                .WithOne(s => s.user);

            modelBuilder.Entity<GuestUser>()
                .HasMany(u => u.Shipments)
                .WithOne(s => s.guestUser);

            // User seed data
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 1, FirstName = "Lars", LastName = "Svensson", Email = "lars.svensson@hotmail.com", Country = "Sweden", PostalCode = 12345, PhoneNumber = 0192987801 });
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 2, FirstName = "Bosse", LastName = "Svenssonson", Email = "bosse.jobb@hotmail.com", Country = "Norway", PostalCode = 67890, PhoneNumber = 019230232 });
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 3, FirstName = "Karl", LastName = "Svenssonsonson", Email = "karl@hotmail.com", Country = "Germany", PostalCode = 09876, PhoneNumber = 0190239294 });
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 4, FirstName = "Henrik", LastName = "Karlsson", Email = "henke12@hotmail.com", Country = "Denmark", PostalCode = 54321, PhoneNumber = 019928323 });
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 5, FirstName = "Magnus", LastName = "Larsson", Email = "festhosmange@hotmail.com", Country = "Sweden", PostalCode = 10238, PhoneNumber = 019985492 });
            modelBuilder.Entity<User>()
                .HasData(new User { UserId = 6, FirstName = "Stig", LastName = "Ottoson", Email = "stigmeister@hotmail.com", Country = "India", PostalCode = 39292, PhoneNumber = 0191291484 });
            // GuestUser seed data
            modelBuilder.Entity<GuestUser>()
                .HasData(new GuestUser { GuestUserId = 1, Email = "svanteboss@gmail.com" });
            modelBuilder.Entity<GuestUser>()
                .HasData(new GuestUser { GuestUserId = 2, Email = "tjaman@hotmail.com" });
            modelBuilder.Entity<GuestUser>()
                .HasData(new GuestUser { GuestUserId = 3, Email = "coolmanyes@hotmail.com" });
            // Shipment seed data
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId = 1, RecieverName = "Torkel", Weight = 2, Destination = "Sweden", BoxColor = "Brown", UserId = 1 });
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId = 2, RecieverName = "Sanjin", Weight = 8, Destination = "Sweden", BoxColor = "Purple", UserId = 4 });
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId = 3, RecieverName = "Ibrahim", Weight = 5, Destination = "Germany", BoxColor = "White", UserId = 5 });
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId = 4, RecieverName = "Tim", Weight = 8, Destination = "Sweden", BoxColor = "Yellow", UserId = 2 });
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId =5, RecieverName = "Jonas", Weight = 1, Destination = "Norway", BoxColor = "White", GuestUserId = 1 });
            modelBuilder.Entity<Shipment>()
                .HasData(new Shipment { ShipmentId = 6, RecieverName = "Jonte", Weight = 2, Destination = "Denmark", BoxColor = "Black", GuestUserId = 3  });
            // Multiplier seed data
            modelBuilder.Entity<Multiplier>()
                .HasData(new Multiplier { MultiplierId = 1, MultiplierNumber = 5, Country = "Norway" });
            modelBuilder.Entity<Multiplier>()
                .HasData(new Multiplier { MultiplierId = 2, MultiplierNumber = 10, Country = "Germany" });
            modelBuilder.Entity<Multiplier>()
                .HasData(new Multiplier { MultiplierId = 3, MultiplierNumber = 4, Country = "Sweden" });


        }
    }
}
