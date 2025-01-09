namespace IMS.WebApp.Client.Authentication
{
    public interface ITokenService
    {
        Task SetTokenAsync(string token);
        Task<string?> GetTokenAsync();
        Task<string?> GetRoleFromTokenAsync();
        Task<string?> GetUserNameFromTokenAsync();
        Task<string?> GetUserEmailFromTokenAsync(string token);
        Task<string?> GetUserIdFromTokenAsync();
        Task SetPreTokenToSessionAsync(string token);
        Task<string> GetPreTokenFromSessionAsync();
        Task RemoveTokenAsync();
        Task RemoveBreadcrumbAsync();
    }
}
