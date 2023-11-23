using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface ITourOrderService
    {
        Task<long> AddAsync(TourOrder entity);
        Task<IList<TourOrder>> GetAllAsync();
        Task<IList<TourOrder>> WhereAsync(Expression<Func<TourOrder, bool>> predicate);
        Task<TourOrder> GetByIdAsync(long id);
        Task<long> UpdateAsync(TourOrder entity);
        Task RemoveAsync(TourOrder entity);
        Task<IList<TourOrder>> IncludeAsync(params string[] relations);
    }
}
