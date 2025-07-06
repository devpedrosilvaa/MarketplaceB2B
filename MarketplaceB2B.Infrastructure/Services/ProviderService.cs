using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Infrastructure.Services {
    public class ProviderService : IProviderService {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository) {
            _providerRepository = providerRepository;
        }
        public async Task<Provider> SaveProvider(Provider provider) {
            try {
                return await _providerRepository.SaveProvider(provider);  
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
    }
}
