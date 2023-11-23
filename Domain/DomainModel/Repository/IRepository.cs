﻿using System.Linq.Expressions;

namespace DomainModel.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<IList<T>> WhereAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(long id);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<IList<T>> IncludeAsync(params string[] relations);
    }
}
