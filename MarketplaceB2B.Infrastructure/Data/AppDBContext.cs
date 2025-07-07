using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MarketplaceB2B.Infrastructure.Identities;
<<<<<<< HEAD
using MarketplaceB2B.Domain.Entities;
=======
>>>>>>> origin/main

namespace MarketplaceB2B.Infrastructure.Data {
    public class AppDBContext : IdentityDbContext<AppUser> {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

<<<<<<< HEAD
        public DbSet<AppProvider> Providers { get; set; }
=======
>>>>>>> origin/main

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );
<<<<<<< HEAD

            modelBuilder.Entity<AppProvider>().HasOne(p => p.AppUser)
                .WithOne(u => u.Provider)
                .HasForeignKey<AppProvider>(p => p.AppUserId);
=======
>>>>>>> origin/main
        }
    }
}
