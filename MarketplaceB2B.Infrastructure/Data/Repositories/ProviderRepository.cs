using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Application.Mappers;
using MarketplaceB2B.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketplaceB2B.Infrastructure.Data.Repositories {
    public class ProviderRepository : IProviderRepository {
        private readonly AppDBContext _dbContext;
        public ProviderRepository(AppDBContext dbContext) {
            _dbContext = dbContext;
        }

        public async Task<Provider?> GetProviderByCPF(string CPF) {
            var provider = await _dbContext.Providers.FirstOrDefaultAsync(
                                    p => p.CPF!.Equals(CPF));
            return provider != null ? provider.ProviderIdentityToDomain() : null;
        }

        public async Task<Provider?> GetProviderByUserId(string userId) {
            var provider = await _dbContext.Providers.FirstOrDefaultAsync(
                                    p => p.AppUserId!.Equals(userId));
            return provider != null ? provider.ProviderIdentityToDomain() : null;
        }

        public async Task<Provider> SaveProvider(Provider provider) {
            var providerSaved = await _dbContext.Providers.AddAsync(provider.ProviderDomainToIdentity());
            await _dbContext.SaveChangesAsync();
            return providerSaved.Entity.ProviderIdentityToDomain();
        }
    }
}
