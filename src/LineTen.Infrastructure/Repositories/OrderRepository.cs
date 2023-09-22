using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using System.Data.Entity;

namespace LineTen.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly LineTenContext _context;

        public OrderRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            await _context.AddAsync(order);

            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            var orderToDelete = await _context.FindAsync<Order>(id);

            if (orderToDelete != null)
            {
                _context.Remove(orderToDelete);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.FindAsync<Order>(id);

            return order ?? new Order();
        }

        public async Task<Order> UpdateOrderAsync(int id, Order order)
        {
            var existingOrderRecord = await _context.FindAsync<Order>(id);

            if (existingOrderRecord != null)
            {
                existingOrderRecord.ProductId = order.ProductId;
                existingOrderRecord.CustomerId = order.CustomerId;
                existingOrderRecord.Status = order.Status;

                await _context.SaveChangesAsync();

                return existingOrderRecord;
            }

            return new Order();
        }
    }
}
