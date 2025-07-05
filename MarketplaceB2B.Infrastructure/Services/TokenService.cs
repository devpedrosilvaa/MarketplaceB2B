using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Infrastructure.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using MarketplaceB2B.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MarketplaceB2B.Infrastructure.Services {
    public class TokenService : ITokenService {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;

        public TokenService(IConfiguration configuration, UserManager<AppUser> userManager) {
            _configuration = configuration;
            _key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JwrBearer:Key"]));
            _userManager = userManager;
        }

        public async Task<string> GenerateToken(User user) {
            var AppUser = await _userManager.FindByNameAsync(user.UserName);
            var userRoles = await _userManager.GetRolesAsync(AppUser);
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, AppUser.Email),
                new Claim(ClaimTypes.GivenName, AppUser.UserName)
            };
            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _configuration["JwtBearer:Issuer"],
                Audience = _configuration["JwtBearer:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
