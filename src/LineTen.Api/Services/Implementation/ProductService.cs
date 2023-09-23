using LineTen.Api.Extensions;
using LineTen.Api.Requests;
using LineTen.Api.Responses;
using LineTen.Api.Services.Interfaces;
using LineTen.Domain.Repositories;

namespace LineTen.Api.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ProductResponse> CreateProductAsync(ProductRequest request)
        {
            var result = await _repository.CreateProductAsync(request.ToProduct());

            return result.ToProductResponse();
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            return await _repository.DeleteProductByIdAsync(id);
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var result = await _repository.GetAllProductsAsync();

            return result.ToProductResponse();
        }

        public async Task<ProductResponse?> GetProductByIdAsync(int id)
        {
            var result = await _repository.GetProductByIdAsync(id);

            return result.ToProductResponse();
        }

        public async Task<ProductResponse> UpdateProductByIdAsync(int id, ProductRequest request)
        {
            var result = await _repository.UpdateProductAsync(id, request.ToProduct());

            return result.ToProductResponse();
        }
    }
}
