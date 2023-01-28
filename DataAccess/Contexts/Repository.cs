using Core.Interface;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
    public class Repository<T> : IRepository<T> where T : class, IEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await _table.AddAsync(entity);
        }

        public void DeleteAsync(T entity)
        {
           _table.Remove(entity);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
