using LineTen.Domain.Entities;

namespace LineTen.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(int id);

        Task UpdateOrderAsync(Order order);

        Task DeleteOrderByIdAsync(int id);
    }
}
