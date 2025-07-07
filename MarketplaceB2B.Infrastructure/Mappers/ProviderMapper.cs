using MarketplaceB2B.Domain.Entities;
using MarketplaceB2B.Infrastructure.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Application.Mappers {
    public static class ProviderMapper {

        public static AppProvider DomainToIdentity(this Provider provider) {
            return new AppProvider {
                CPF = provider.CPF,
                Status = provider.Status,
                AppUserId = provider.AppUserId,
                Description = provider.Description
            };
        }
        public static Provider IdentityToDomain(this AppProvider provider) {
            return new Provider {
                CPF = provider.CPF,
                Status = provider.Status,
                AppUserId = provider.AppUserId,
                Description = provider.Description
            };
        }

    }
}
