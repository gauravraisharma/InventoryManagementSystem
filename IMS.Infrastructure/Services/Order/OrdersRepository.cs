using IMS.Infrastructure.Interface.Order;
using IMS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Services.Order
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetOrdersByCustomerIdAsync(string customerId)
        {
            return await _context.Orders.Include(it => it.AddressTbl)
                .Where(order => order.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Orders>> GetAllOrdersAsync()
        {
            return await _context.Orders.Include(it => it.AddressTbl).ToListAsync();
        }

        public async Task AddOrderAsync(Orders order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Orders?> GetOrderByIdAsync(string orderId)
        {
            try
            {
                return await _context.Orders.Include(it => it.AddressTbl)
                    .FirstOrDefaultAsync(order => order.Id == orderId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error fetching order with ID: {orderId}", ex);
            }
        }

        public async Task UpdateOrderAsync(Orders order)
        {
            try
            {
                _context.Orders.Update(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order with ID: {order.Id}", ex);
            }
        }

        public async Task DeleteOrderByIdAsync(string orderId)
        {
            try
            {
                var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == orderId);
                if (order == null)
                {
                    throw new Exception($"Order with ID: {orderId} not found.");
                }
                _context.Orders.Remove(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting order with ID: {orderId}", ex);
            }
        }
    }
}


