using MarketplaceB2B.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Application.Interfaces {
    public interface IProviderService {
        Task<Provider> SaveProvider(Provider provider);
    }
}
