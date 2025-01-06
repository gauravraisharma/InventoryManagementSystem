
using IMS.Core.Entities;

namespace IMS.Infrastructure.Interface.Address
{
    public interface IAddressRepository
    {
        Task<string> AddAsync(AddressTbl address);
        Task<AddressTbl> GetByIdAsync(string id);
        Task<List<AddressTbl>> GetAllAsync();
        Task UpdateAsync(AddressTbl address);
        Task DeleteAsync(AddressTbl address);
        Task<List<AddressTbl>> GetAddressesByUserIdAsync(string userId);
    }

}
