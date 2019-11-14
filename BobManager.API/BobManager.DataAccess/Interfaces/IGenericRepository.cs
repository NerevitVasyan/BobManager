using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BobManager.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Create(TEntity entity);
        Task<IEnumerable<TEntity>> Create(IEnumerable<TEntity> entities);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Delete(IEnumerable<TEntity> entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllInclude(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> GetAllInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> Find(int Id);
    }
}