using System.Security.Claims;

namespace MarketplaceB2B.API.Extensions {
    public static class ClaimsExtensions {
        public static string GetUsername(this ClaimsPrincipal user) {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var username = user.FindFirstValue(ClaimTypes.GivenName);
            if (username == null)
                throw new ArgumentNullException(nameof(username));
            return username;
        }
    }
}
