using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;

namespace LineTen.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LineTenContext _context;

        public ProductRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task CreateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
