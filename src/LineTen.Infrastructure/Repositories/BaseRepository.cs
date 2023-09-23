using Microsoft.EntityFrameworkCore;

namespace LineTen.Infrastructure.Repositories
{
    public class BaseRepository
    {
        private readonly LineTenContext _context;

        public BaseRepository(LineTenContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<T> CreateAsync<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteByIdAsync<T>(int id) where T : class
        {
            var entityToDelete = await _context.FindAsync<T>(id);

            if (entityToDelete != null)
            {
                _context.Remove(entityToDelete);

                await _context.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<T>> GetAllEntitiesAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            var entity = await _context.FindAsync<T>(id);

            return entity ?? null;
        }
    }
}
