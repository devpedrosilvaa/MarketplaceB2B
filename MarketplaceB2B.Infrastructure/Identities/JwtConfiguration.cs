using MarketplaceB2B.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceB2B.Infrastructure.Identities {
    public class JwtConfiguration : IJwtConfiguration {

        private readonly IConfiguration _configuration;

        public JwtConfiguration(IConfiguration configuration) {
            _configuration = configuration;
        }

        public string GetSecretKey() => _configuration["Jwt:Secret"];
    }
}
