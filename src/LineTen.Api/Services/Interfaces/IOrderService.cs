using LineTen.Api.Requests;
using LineTen.Api.Responses;

namespace LineTen.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderCreateRequest request);

        Task<IEnumerable<OrderResponse>> GetAllOrdersAsync();

        Task<OrderResponse> GetOrderById(int id);

        Task UpdateOrderById(int id, OrderUpdateRequest request);

        Task DeleteOrderById(int id);
    }
}
