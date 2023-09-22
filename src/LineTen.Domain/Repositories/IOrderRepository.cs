using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(Order order);

        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order> GetOrderByIdAsync(int id);

        Task<Order> UpdateOrderAsync(int id, Order order);

        Task<bool> DeleteOrderByIdAsync(int id);
    }
}
