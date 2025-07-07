using MarketplaceB2B.Domain.Enums;

namespace MarketplaceB2B.Infrastructure.Identities {
    public class AppProvider {
        public int Id { get; set; }
        public string? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string? CPF { get; set; }
        public StatusProvider Status { get; set; }
        public string? Description { get; set; }
    }
}
