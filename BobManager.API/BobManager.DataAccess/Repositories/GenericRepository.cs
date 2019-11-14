using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Repositories
{
    public class GenericRepository<TEntity>
        : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext db;

        public GenericRepository(DbContext _db)
        {
            db = _db;
        }

        public async Task<int> CountAll() => await db.Set<TEntity>().CountAsync();


        public async Task<int> CountWhere(Expression<Func<TEntity, bool>> predicate)
          => await db.Set<TEntity>().CountAsync(predicate);

        public async Task Create(TEntity entity)
        {
            var entry = await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
            return entry.Entity;
        }

        public async Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities)
        {
            List<TEntity> added = new List<TEntity>();
            EntityEntry<TEntity> entry;

            foreach (var item in entities) {
                entry = await db.Set<TEntity>().AddAsync(item);
                added.Add(entry.Entity);
            }
            await db.SaveChangesAsync();

            return added;
        }

        public async Task Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(IEnumerable<TEntity> entity)
        {
            db.Set<TEntity>().RemoveRange(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> Find(int Id)
        {
            return await db.Set<TEntity>().FindAsync(Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return await db.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(db.Set<TEntity>().AsQueryable(), 
                (current, includeProperty) =>
                    current.Include(includeProperty)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            return await includes.Aggregate(db.Set<TEntity>().Where(predicate),
                (current, includeProperty) =>
                    current.Include(includeProperty)).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetPaged(int startIndex, int count, params Expression<Func<TEntity, object>>[] includes)
        {
            startIndex = startIndex - 1;
            return await includes.Aggregate(db.Set<TEntity>().AsQueryable(),
                (current, includeProperty) =>
                    current.Include(includeProperty)).Skip(startIndex*count).Take(count).ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}