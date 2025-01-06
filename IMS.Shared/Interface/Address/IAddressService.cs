using IMS.Shared.Common;
using IMS.Shared.RequestDto;

namespace IMS.Shared.Interface.Address
{
    public interface IAddressService
    {
        Task<ApiResponse<List<AddressDTO>>> GetAddressesByUserIdAsync(string userId);
        Task<ApiResponse<string>> AddAddressAsync(string userId, string city, string country, string street);
        Task<ApiResponse<bool>> UpdateAddressAsync(string userId, string addressId, string city, string country, string street, bool isActive);
        Task<ApiResponse<bool>> DeleteAddressAsync(string addressId);

    }
}
