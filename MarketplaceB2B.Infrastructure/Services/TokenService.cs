using MarketplaceB2B.Application.Interfaces;
using MarketplaceB2B.Infrastructure.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;

namespace MarketplaceB2B.Infrastructure.Services {
    public class TokenService : ITokenService {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _key;
        private readonly UserManager<AppUser> _userManager;
        private readonly string _issuer;
        private readonly string _audience;

        public TokenService(UserManager<AppUser> userManager, IOptions<JwtOptions> options) {
            var jwtOptions = options.Value;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            _issuer = jwtOptions.Issuer;
            _audience = jwtOptions.Audience;
            _userManager = userManager;
        }


        public async Task<string> GenerateToken(string UserName) {
            Console.WriteLine("this is jwt's key '" + _audience + "'");
            var AppUser = await _userManager.FindByNameAsync(UserName);
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
                Issuer = _issuer,
                Audience = _audience
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
