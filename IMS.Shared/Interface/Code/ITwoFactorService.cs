using IMS.Shared.Common;

namespace IMS.Shared.Interface.Code
{
    public interface ITwoFactorService
    {
        Task<ApiResponse<string>> SendCodeAsync(string email);
        Task<ApiResponse<bool>> ValidateCode(string email, string code);
    }
}
