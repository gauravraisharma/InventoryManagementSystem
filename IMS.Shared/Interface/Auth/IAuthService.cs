using IMS.Shared.Common;

namespace IMS.Shared.Interface.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> Login(string username, string password);
        Task<ApiResponse<bool>> Register(string firstname, string lastname, string username, string email, string password);
    }
}
