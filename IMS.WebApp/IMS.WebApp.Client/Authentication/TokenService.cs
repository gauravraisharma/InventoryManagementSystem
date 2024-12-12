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
    }
}
