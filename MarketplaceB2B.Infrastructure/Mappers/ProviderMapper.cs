using MarketplaceB2B.Application.Dtos;
using MarketplaceB2B.Domain.Entities;
using MarketplaceB2B.Infrastructure.Identities;
using MarketplaceB2B.Infrastructure.Mappers;

namespace MarketplaceB2B.Application.Mappers {
    public static class ProviderMapper {
        public static AppProvider ProviderDomainToIdentity(this Provider provider) {
            return new AppProvider {
                CPF = provider.CPF,
                Status = provider.Status,
                AppUserId = provider.AppUserId,
                Description = provider.Description
            };
        }

        public static Provider ProviderIdentityToDomain(this AppProvider provider) {
            return new Provider {
                CPF = provider.CPF,
                Status = provider.Status,
                User = provider.AppUser!.UserIdentityToDomain(),
                AppUserId = provider.AppUserId,
                Description = provider.Description,
            };
        }

        public static ProviderResponseDTO ProviderDomainToResponse(this Provider provider) {
            return new ProviderResponseDTO {
                Id = provider.Id,
                User = provider.User!.UserDomainToResponse(),
                CPF = provider.CPF,
                Description = provider.Description,
                Status = provider.Status.ToString(),
            };
        }
    }
}
