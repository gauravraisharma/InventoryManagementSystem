namespace IMS.WebApp.Client.Authentication
{
    public interface ITokenService
    {
        Task SetTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task<string?> GetRoleFromTokenAsync();
        Task<string?> GetUserNameFromTokenAsync();
        Task<string?> GetUserIdFromTokenAsync();
        Task RemoveTokenAsync();
    }
}
