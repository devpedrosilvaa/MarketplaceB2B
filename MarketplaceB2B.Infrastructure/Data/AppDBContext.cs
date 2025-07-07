using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MarketplaceB2B.Infrastructure.Identities;
using MarketplaceB2B.Domain.Entities;

namespace MarketplaceB2B.Infrastructure.Data {
    public class AppDBContext : IdentityDbContext<AppUser> {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<AppProvider> Providers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );

            modelBuilder.Entity<AppProvider>()
                .HasOne(p => p.AppUser)
                .WithOne(u => u.Provider)
                .HasForeignKey<AppProvider>(p => p.AppUserId);
            
            modelBuilder.Entity<AppProvider>()
                .HasIndex(p => p.CPF)
                .IsUnique();
        }
    }
}
