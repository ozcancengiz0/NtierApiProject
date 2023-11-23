using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface ITourService
    {
        Task<long> AddAsync(Tour entity);
        Task<IList<Tour>> GetAllAsync();
        Task<IList<Tour>> WhereAsync(Expression<Func<Tour, bool>> predicate);
        Task<Tour> GetByIdAsync(long id);
        Task<long> UpdateAsync(Tour entity);
        Task RemoveAsync(Tour entity);
        Task<IList<Tour>> IncludeAsync(params string[] relations);
    }
}
