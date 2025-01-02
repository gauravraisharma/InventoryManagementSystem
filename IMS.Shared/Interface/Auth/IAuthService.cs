using IMS.Shared.Common;
using IMS.Shared.RequestDto.UserDTOs;

namespace IMS.Shared.Interface.Auth
{
    public interface IAuthService
    {
        Task<ApiResponse<string>> Login(string username, string password);
        Task<ApiResponse<bool>> Register(string firstname, string lastname, string username, string email, string password);
        Task<ApiResponse<List<ApplicationUserDto>>> GetAllUsers();
        Task<ApiResponse<ApplicationUserDto>> GetUserById(string id);
        Task<ApiResponse<bool>> UpdateUserProfile(string userId, string email, string phone, string firstName, string lastName, string address);
    }
}
