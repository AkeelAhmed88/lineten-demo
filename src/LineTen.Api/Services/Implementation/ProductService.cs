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

        public Task CreateProductAsync(ProductRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductResponse> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductById(int id, ProductRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
