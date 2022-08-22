using BiddingApp.Domain.Models;
using BiddingApp.Infrastructure.Configurations;
using BiddingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingApp.Infrastructure.Data
{
    public class BiddingAppContext : DbContext
    {
        public BiddingAppContext(DbContextOptions<BiddingAppContext> options) : base(options) { }
        public DbSet<ClientProfile> ClientProfiles { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ClientNotification> ClientNotifications { get; set; }
        public DbSet<CompanyNotification> CompanyNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .UseSqlServer(@"Data Source=(localdb)\local;Initial Catalog=BiddingApp.Database;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CardConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new ClientNotificationConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyNotificationConfiguration());
        }
    }
}
