using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using System.Data.Entity;

namespace LineTen.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        private readonly LineTenContext _context;

        public OrderRepository(LineTenContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            return await CreateAsync(order);
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            return await DeleteByIdAsync<Order>(id);
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await GetAllEntitiesAsync<Order>();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await GetByIdAsync<Order>(id);
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
