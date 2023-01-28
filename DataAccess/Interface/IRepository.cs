using Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IRepository<T> where T : class,IEntity,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(int id);
        Task CreateAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task SaveAsync();
    }
}
