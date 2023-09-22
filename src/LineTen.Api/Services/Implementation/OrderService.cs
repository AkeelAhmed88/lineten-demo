using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using LineTen.Domain.Repositories;

namespace LineTen.Api.Services.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public Task<OrderResponse> CreateOrderAsync(OrderCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> UpdateOrderByIdAsync(int id, OrderUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
