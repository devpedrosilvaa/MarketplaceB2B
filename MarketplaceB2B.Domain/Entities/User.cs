using MarketplaceB2B.Domain.Enums;

namespace MarketplaceB2B.Domain.Entities {
    public class User {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public TypeUser TypeUser { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
