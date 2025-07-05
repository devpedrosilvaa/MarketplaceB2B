using MarketplaceB2B.Domain.Entities;

namespace MarketplaceB2B.Application.Interfaces {
    public interface ITokenService {
        Task<string> GenerateToken(User user);
    }
}
