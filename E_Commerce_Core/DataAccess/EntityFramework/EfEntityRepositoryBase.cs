using E_Commerce_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace E_Commerce_Core.DataAccess.EntityFramework
{
   public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity, new()
       where TContext : DbContext, new()
   {
      public void Add(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
         }
      }

      public async Task AddAsync(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var addedEntity = context.Entry(entity);
            addedEntity.State = EntityState.Added;
            await context.SaveChangesAsync();
         }
      }

      public void Update(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
         }
      }

      public async Task UpdateAsync(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await context.SaveChangesAsync();
         }
      }

      public void Delete(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            context.SaveChanges();
         }
      }

      public async Task DeleteAsync(TEntity entity)
      {
         using (TContext context = new TContext())
         {
            var deletedEntity = context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            await context.SaveChangesAsync();
         }
      }

      public TEntity? Get(Expression<Func<TEntity, bool>> filter)
      {
         using (TContext context = new TContext())
         {
            return context.Set<TEntity>().SingleOrDefault(filter);
         }
      }

      public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
      {
         using (TContext context = new TContext())
         {
            return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
         }
      }

      public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
      {
         using (TContext context = new TContext())
         {
            return filter == null
                ? context.Set<TEntity>().Select(entity => entity)
                : context.Set<TEntity>().Where(filter).Select(entity => entity);
         }
      }

      public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
      {
         using (TContext context = new TContext())
         {
            return filter == null
                ? await context.Set<TEntity>().ToListAsync()
                : await context.Set<TEntity>().Where(filter).ToListAsync();
         }
      }

      public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> filter = null)
      {
         using (TContext context = new TContext())
         {
            return filter == null
                ? context.Set<TEntity>().ToList()
                : context.Set<TEntity>().Where(filter).ToList();
         }
      }
   }
}
