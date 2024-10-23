using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {}

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}
