using BobManager.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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

        public void Create(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);
            db.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            db.SaveChanges();
        }

        public TEntity Find(int Id)
        {
            return db.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return db.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAllInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = db.Set<TEntity>().AsQueryable();
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public IEnumerable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = db.Set<TEntity>().Where(predicate);
            return includes.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}