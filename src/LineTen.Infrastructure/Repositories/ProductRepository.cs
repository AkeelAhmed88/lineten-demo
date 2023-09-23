using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;

namespace LineTen.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly LineTenContext _context;

        public ProductRepository(LineTenContext context)
            : base(context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            return await CreateAsync(product);
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            return await DeleteByIdAsync<Product>(id);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await GetAllEntitiesAsync<Product>();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await GetByIdAsync<Product>(id);
        }

        public async Task<Product> UpdateProductAsync(int id, Product product)
        {
            var existingProductRecord = await _context.FindAsync<Product>(id);

            if (existingProductRecord != null)
            {
                existingProductRecord.Name = product.Name;
                existingProductRecord.Description = product.Description;
                existingProductRecord.Sku = product.Sku;

                await _context.SaveChangesAsync();

                return existingProductRecord;
            }

            return new Product();
        }
    }
}
