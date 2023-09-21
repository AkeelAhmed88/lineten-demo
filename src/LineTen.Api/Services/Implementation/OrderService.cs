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

        public Task CreateOrderAsync(OrderCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderResponse> GetOrderById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrderById(int id, OrderUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
