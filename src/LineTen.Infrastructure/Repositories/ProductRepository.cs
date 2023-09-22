using LineTen.Domain.Entities;
using LineTen.Domain.Repositories;
using System.Data.Entity;

namespace LineTen.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LineTenContext _context;

        public ProductRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.AddAsync(product);

            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProductByIdAsync(int id)
        {
            var productToDelete = await _context.FindAsync<Product>(id);

            if (productToDelete != null)
            {
                _context.Remove(productToDelete);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var product = await _context.FindAsync<Product>(id);

            return product ?? new Product();
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
