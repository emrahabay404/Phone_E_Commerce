using E_Commerce_Core.Entities;
using System.Linq.Expressions;

namespace E_Commerce_Core.DataAccess
{
   public interface IEntityRepository<T>
        where T : class, IEntity, new()
   {
      List<T> GetAllList(Expression<Func<T, bool>> filter = null);
      IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
      T Get(Expression<Func<T, bool>> filter);
      void Add(T entity);
      Task AddAsync(T entity);
      void Update(T entity);
      void Delete(T entity);
      Task UpdateAsync(T entity);
      Task DeleteAsync(T entity);
      Task<T?> GetAsync(Expression<Func<T, bool>> filter);
      Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
   }
}
