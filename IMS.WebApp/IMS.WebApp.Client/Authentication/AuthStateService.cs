using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace IMS.WebApp.Client.Authentication
{
    public class AuthStateService : AuthenticationStateProvider
    {
        private readonly ITokenService _tokenService;
        public string UserRole { get; set; } = string.Empty;

        public AuthStateService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _tokenService.GetTokenAsync();

            if (string.IsNullOrWhiteSpace(token))
            {
                // No token means no authentication
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            // Decode the token and create claims
            var claimsIdentity = new ClaimsIdentity(ParseClaimsFromJwt(token), "jwt");
            var user = new ClaimsPrincipal(claimsIdentity);

            return new AuthenticationState(user);
        }

        public void NotifyAuthenticationStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        private IEnumerable<Claim> ParseClaimsFromJwt(string jwt)
        {
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);
            return token.Claims;
        }
    }
}
