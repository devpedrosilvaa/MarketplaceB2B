using MarketplaceB2B.Domain.Entities;

namespace MarketplaceB2B.Application.Interfaces {
    public interface IProviderService {
        Task<string> SaveProvider(Provider provider);
        Task<Provider?> GetProviderByUserId(string userId);
    }
}
