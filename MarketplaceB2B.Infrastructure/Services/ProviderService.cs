using MarketplaceB2B.Application.Helpers;
using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Domain.Entities;

namespace MarketplaceB2B.Infrastructure.Services {
    public class ProviderService : IProviderService {
        private readonly IProviderRepository _providerRepository;
        public ProviderService(IProviderRepository providerRepository) {
            _providerRepository = providerRepository;
        }
        public async Task<string> SaveProvider(Provider provider) {
            string message = string.Empty;
            try {
                var providerSaved = await _providerRepository.GetProviderByUserId(provider.AppUserId!);
                if (providerSaved == null)
                    providerSaved = await _providerRepository.GetProviderByCPF(provider.CPF!);
                if (providerSaved != null)
                    message = Helper.StringValueOf(Helper.DefaultMessage.EXISTING_RECORD);
                else {
                    await _providerRepository.SaveProvider(provider);
                    message = Helper.StringValueOf(Helper.DefaultMessage.INSERT);
                }
                Console.WriteLine(message);
                return message;
            }
            catch (Exception ex) {
                message = ex.Message;
                return message;
            }
        }

        public async Task<Provider?> GetProviderByUserId(string userId) {
            try {
                return await _providerRepository.GetProviderByUserId(userId);
            }
            catch { 
                return null; 
            }
        }
    }
}
