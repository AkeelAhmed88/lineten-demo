using LineTen.Api.Extensions;
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

        public async Task<OrderResponse> CreateOrderAsync(OrderCreateRequest request)
        {
            var result = await _repository.CreateOrderAsync(request.ToOrder());

            return result.ToOrderResponse();
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            return await _repository.DeleteOrderByIdAsync(id);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var result = await _repository.GetAllOrdersAsync();

            return result.ToOrderResponse();
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(int id)
        {
            var result = await _repository.GetOrderByIdAsync(id);

            return result.ToOrderResponse();
        }

        public async Task<OrderResponse> UpdateOrderByIdAsync(int id, OrderUpdateRequest request)
        {
            var result = await _repository.UpdateOrderAsync(id, request.ToOrder());

            return result.ToOrderResponse();
        }
    }
}
