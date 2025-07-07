using MarketplaceB2B.Application.Helpers;
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
        public async Task<string> SaveProvider(Provider provider) {
            string message = string.Empty;
            try {
                var providerSaved = _providerRepository.GetProviderByUserId(provider.AppUserId!);
                if (providerSaved == null)
                    providerSaved = _providerRepository.GetProviderByCPF(provider.CPF!);
                if (providerSaved != null)
                    message = Helper.DefaultMessage.EXISTING_RECORD.ToString();
                else {
                    await _providerRepository.SaveProvider(provider);
                    message = Helper.DefaultMessage.INSERT.ToString();
                }
                return message;
            }
            catch (Exception ex) {
                message = ex.Message;
                return message;
            }
        }
    }
}
