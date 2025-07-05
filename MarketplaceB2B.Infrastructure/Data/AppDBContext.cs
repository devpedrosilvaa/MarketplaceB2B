using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MarketplaceB2B.Infrastructure.Identities;

namespace MarketplaceB2B.Infrastructure.Data {
    public class AppDBContext : IdentityDbContext<AppUser> {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );
        }
    }
}
