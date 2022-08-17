using BiddingApp.Domain.Models;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder
                .UseSqlServer(@"Data Source=(localdb)\local;Initial Catalog=BiddingApp.Database;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Images)
                .WithOne();
            modelBuilder.Entity<CompanyProfile>()
                .HasMany(product => product.Products)
                .WithOne()
                .HasForeignKey(x => x.CompanyProfileId);
            modelBuilder.Entity<Product>()
                .HasMany(product => product.Reviews)
                .WithOne();
            modelBuilder.Entity<ClientProfile>()
                .HasMany(client => client.Cards)
                .WithOne()
                .HasForeignKey(x => x.ClientProfileId);
            modelBuilder.Entity<ClientProfile>()
                .HasMany(client => client.Reviews)
                .WithOne()
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
