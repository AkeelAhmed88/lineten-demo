using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrderAsync(OrderCreateRequest request);

        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();

        Task<OrderResponse?> GetOrderByIdAsync(int id);

        Task<OrderResponse> UpdateOrderByIdAsync(int id, OrderUpdateRequest request);

        Task<bool> DeleteOrderByIdAsync(int id);
    }
}
