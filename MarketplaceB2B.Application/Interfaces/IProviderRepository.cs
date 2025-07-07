using MarketplaceB2B.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Application.Interfaces {
    public interface IProviderRepository {
        Task<Provider> SaveProvider(Provider provider);
        Task<Provider?> GetProviderByUserId(string userId);
        Task<Provider?> GetProviderByCPF(string CPF);
    }
}
