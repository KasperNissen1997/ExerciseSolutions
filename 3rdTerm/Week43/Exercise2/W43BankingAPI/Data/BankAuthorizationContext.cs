using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using W43BankingAPI.Models.Identity;

namespace W43BankingAPI.Data
{
    public class BankAuthorizationContext : IdentityDbContext
    {
        public BankAuthorizationContext(DbContextOptions options) : base(options) { }

        public DbSet<BankUser> BankUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BankUser>()
                .HasKey(m => m.Email);

            base.OnModelCreating(builder);
        }
    }
}
