using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Data
{
    public class ApplicationDbContext : IdentityDbContext<Vendor>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {}

        public DbSet<Project> Projects { get; set; }
        public DbSet<Bid> Bids { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Bid>()
            .Property(b => b.Amount)
            .HasPrecision(18, 2);

            base.OnModelCreating(builder);
        }

    }
}
