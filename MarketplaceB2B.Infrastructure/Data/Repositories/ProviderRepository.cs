using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Application.Mappers;
using MarketplaceB2B.Domain.Entities;

namespace MarketplaceB2B.Infrastructure.Data.Repositories {
    public class ProviderRepository : IProviderRepository {
        private readonly AppDBContext _dbContext;
        public ProviderRepository(AppDBContext dbContext) {
            _dbContext = dbContext;
        }
        public async Task<Provider> SaveProvider(Provider provider) {
            var providerSaved = await _dbContext.Providers.AddAsync(provider.DomainToIdentity());
            await _dbContext.SaveChangesAsync();
            return providerSaved.Entity.IdentityToDomain();
        }
    }
}
