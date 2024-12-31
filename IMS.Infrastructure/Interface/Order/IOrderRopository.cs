namespace IMS.Infrastructure.Interface.Order
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersByCustomerIdAsync(string customerId);
        Task<List<Orders>> GetAllOrdersAsync();
        Task AddOrderAsync(Orders order);
        Task SaveChangesAsync();
        Task DeleteOrderByIdAsync(string orderId);
        Task UpdateOrderAsync(Orders order);
        Task<Orders?> GetOrderByIdAsync(string orderId);
    }

}
