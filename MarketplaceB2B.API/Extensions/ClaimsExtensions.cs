using System.Security.Claims;

namespace MarketplaceB2B.API.Extensions {
    public static class ClaimsExtensions {
        public static string GetUsername(this ClaimsPrincipal user) {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            return user.FindFirstValue(ClaimTypes.GivenName);
        }
    }
}
