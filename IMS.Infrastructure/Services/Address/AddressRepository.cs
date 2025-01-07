using IMS.Core.Entities;
using IMS.Infrastructure.Interface.Address;
using IMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public class AddressRepository : IAddressRepository
{
    private readonly ApplicationDbContext _context;

    public AddressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<string> AddAsync(AddressTbl address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();
        return address.Id;
    }

    public async Task<AddressTbl> GetByIdAsync(string id)
    {
        return await _context.Addresses.FindAsync(id);
    }

    public async Task<List<AddressTbl>> GetAllAsync()
    {
        return await _context.Addresses.ToListAsync();
    }
    public async Task<List<AddressTbl>> GetAddressesByUserIdAsync(string userId)
    {
        return await _context.Addresses.Where(a => a.UserId == userId && a.IsDelete == false).ToListAsync();
    }
    public async Task<List<AddressTbl>> GetPrimaryAddressByUserIdAsync(string userId)
    {
        return await _context.Addresses.Where(a => a.UserId == userId && a.IsDelete == false && a.IsActive == true).ToListAsync();
    }

    public async Task UpdateAsync(AddressTbl address)
    {
        _context.Addresses.Update(address);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(AddressTbl address)
    {
        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();
    }
}
