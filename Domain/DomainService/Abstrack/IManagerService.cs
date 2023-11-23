using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IManagerService
    {
        Task<long> AddAsync(Manager entity);
        Task<IList<Manager>> GetAllAsync();
        Task<IList<Manager>> WhereAsync(Expression<Func<Manager, bool>> predicate);
        Task<Manager> GetByIdAsync(long id);
        Task<long> UpdateAsync(Manager entity);
        Task RemoveAsync(Manager entity);
        Task<IList<Manager>> IncludeAsync(params string[] relations);
    }
}
