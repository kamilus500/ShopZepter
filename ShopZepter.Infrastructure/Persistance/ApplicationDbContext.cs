using Microsoft.EntityFrameworkCore;
using ShopZepter.Domain.Entities;

namespace ShopZepter.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderShop> OrderShops { get; set; }
        public DbSet<OrderClient> OrderClients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderShop>()
                .HasKey(c => new { c.ShopId, c.OrderId });

            modelBuilder.Entity<OrderShop>()
                .HasOne(c => c.Order)
                .WithMany(c => c.OrderShops)
                .HasForeignKey(c => c.OrderId);

            modelBuilder.Entity<OrderShop>()
                .HasOne(c => c.Shop)
                .WithMany(c => c.OrderShops)
                .HasForeignKey(c => c.ShopId);

            modelBuilder.Entity<OrderClient>()
                .HasKey(c => new { c.OrderId, c.ClientId });

            modelBuilder.Entity<OrderClient>()
                .HasOne(c => c.Order)
                .WithMany(c => c.OrderClients)
                .HasForeignKey(c => c.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderClient>()
                .HasOne(c => c.Client)
                .WithMany(c => c.OrderClients)
                .HasForeignKey(c => c.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
