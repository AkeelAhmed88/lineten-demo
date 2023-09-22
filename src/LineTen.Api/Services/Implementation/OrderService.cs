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

            return new OrderResponse
            {
                Id = result.Id,
                Product = new ProductResponse
                {
                    Id = result.Product.Id,
                    Name = result.Product.Name,
                    Description = result.Product.Description,
                    Sku = result.Product.Sku,
                },
                Customer = new CustomerResponse
                {
                    Id = result.Customer.Id,
                    FirstName = result.Customer.FirstName,
                    LastName = result.Customer.LastName,
                    Phone = result.Customer.Phone,
                    Email = result.Customer.Email,
                },
                Status = result.Status,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<bool> DeleteOrderByIdAsync(int id)
        {
            return await _repository.DeleteOrderByIdAsync(id);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var result = await _repository.GetAllOrdersAsync();

            return result.Select(o => new OrderResponse
            {
                Id = o.Id,
                Product = new ProductResponse
                {
                    Id = o.Product.Id,
                    Name = o.Product.Name,
                    Description = o.Product.Description,
                    Sku = o.Product.Sku,
                },
                Customer = new CustomerResponse
                {
                    Id = o.Customer.Id,
                    FirstName = o.Customer.FirstName,
                    LastName = o.Customer.LastName,
                    Phone = o.Customer.Phone,
                    Email = o.Customer.Email,
                },
                Status = o.Status,
                CreatedDate = o.CreatedDate,
                UpdatedDate = o.UpdatedDate
            });
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int id)
        {
            var result = await _repository.GetOrderByIdAsync(id);

            return new OrderResponse
            {
                Id = result.Id,
                Product = new ProductResponse
                {
                    Id = result.Product.Id,
                    Name = result.Product.Name,
                    Description = result.Product.Description,
                    Sku = result.Product.Sku,
                },
                Customer = new CustomerResponse
                {
                    Id = result.Customer.Id,
                    FirstName = result.Customer.FirstName,
                    LastName = result.Customer.LastName,
                    Phone = result.Customer.Phone,
                    Email = result.Customer.Email,
                },
                Status = result.Status,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }

        public async Task<OrderResponse> UpdateOrderByIdAsync(int id, OrderUpdateRequest request)
        {
            var result = await _repository.UpdateOrderAsync(id, request.ToOrder());

            return new OrderResponse
            {
                Id = result.Id,
                Product = new ProductResponse
                {
                    Id = result.Product.Id,
                    Name = result.Product.Name,
                    Description = result.Product.Description,
                    Sku = result.Product.Sku,
                },
                Customer = new CustomerResponse
                {
                    Id = result.Customer.Id,
                    FirstName = result.Customer.FirstName,
                    LastName = result.Customer.LastName,
                    Phone = result.Customer.Phone,
                    Email = result.Customer.Email,
                },
                Status = result.Status,
                CreatedDate = result.CreatedDate,
                UpdatedDate = result.UpdatedDate
            };
        }
    }
}
