namespace IMS.Infrastructure.Interface.Order
{
    public interface IOrderRepository
    {
        Task<List<Orders>> GetOrdersByCustomerIdAsync(string customerId);
        Task<List<Orders>> GetAllOrdersAsync();
        Task AddOrderAsync(Orders order);
        Task SaveChangesAsync();
    }

}
