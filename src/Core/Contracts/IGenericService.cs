using CrunchyAppBackend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrunchyAppBackend.Common.Pagination;

namespace CrunchyAppBackend.Core.Contracts
{
    public interface IGenericService<TEntity> where TEntity : class, IEntity
    {
        public Task<TEntity> Create(TEntity entity);
        public Task<bool> Create(IEnumerable<TEntity> entities);
        public Task<(bool exists, TEntity entity)> CreateOrUpdate(TEntity entity);
        public Task<bool> Delete(int id);
        public Task<bool> Delete(TEntity entity);
        public Task<bool> Delete(IEnumerable<TEntity> entities);
        public Task<TEntity> Find(int id, params Expression<Func<TEntity, object>>[] navigationProperties);
        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] navigationProperties);
        public Task<IEnumerable<TEntity>> Get(params Expression<Func<TEntity, object>>[] navigationProperties);
        public Task<PaginatedResult<TEntity>> GetPaginatedList(PaginatedRequest request, params Expression<Func<TEntity, object>>[] navigationProperties);
        public Task<bool> Update(TEntity entity);
        public Task<bool> Update(IEnumerable<TEntity> entities);
    }
}