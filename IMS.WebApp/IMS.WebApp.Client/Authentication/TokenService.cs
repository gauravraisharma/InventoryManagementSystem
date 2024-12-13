using System.IdentityModel.Tokens.Jwt;
using Blazored.LocalStorage;

namespace IMS.WebApp.Client.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly ILocalStorageService _localStorage;
        private const string TokenKey = "authToken";

        public TokenService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        /// <summary>
        /// Stores the token in local storage.
        /// </summary>
        /// <param name="token">The token to store.</param>
        public async Task SetTokenAsync(string token)
        {
            await _localStorage.SetItemAsync(TokenKey, token);
        }

        /// <summary>
        /// Retrieves the token from local storage.
        /// </summary>
        /// <returns>The stored token or null if not found.</returns>
        public async Task<string?> GetTokenAsync()
        {
            return await _localStorage.GetItemAsync<string>(TokenKey);
        }

        /// <summary>
        /// Removes the token from local storage.
        /// </summary>
        public async Task RemoveTokenAsync()
        {
            await _localStorage.RemoveItemAsync(TokenKey);
        }

        /// <summary>
        /// Extracts the role from the JWT stored in local storage.
        /// </summary>
        /// <returns>The role if present, otherwise null.</returns>
        public async Task<string?> GetRoleFromTokenAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                return null;

            try
            {
                var jwtHandler = new JwtSecurityTokenHandler();

                if (!jwtHandler.CanReadToken(token))
                    return null;

                var jwtToken = jwtHandler.ReadJwtToken(token);

                var role = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("role"))?.Value;

                return role;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetUserIdFromTokenAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                return null;

            try
            {
                var jwtHandler = new JwtSecurityTokenHandler();

                if (!jwtHandler.CanReadToken(token))
                    return null;

                var jwtToken = jwtHandler.ReadJwtToken(token);

                var role = jwtToken.Claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;

                return role;
            }
            catch
            {
                return null;
            }
        }

        public async Task<string?> GetUserNameFromTokenAsync()
        {
            var token = await GetTokenAsync();
            if (string.IsNullOrWhiteSpace(token))
                return null;

            try
            {
                var jwtHandler = new JwtSecurityTokenHandler();

                if (!jwtHandler.CanReadToken(token))
                    return null;

                var jwtToken = jwtHandler.ReadJwtToken(token);

                // Match the claim type exactly for "name"
                var nameClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
                var userName = jwtToken.Claims
                    .FirstOrDefault(c => string.Equals(c.Type, nameClaimType, StringComparison.OrdinalIgnoreCase))?.Value;

                return userName;
            }
            catch
            {
                return null;
            }
        }
    }
}
