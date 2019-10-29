using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task Create(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
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

        public async Task Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}