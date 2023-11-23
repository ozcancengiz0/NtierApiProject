using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IHotelOrderService
    {
        Task<long> AddAsync(HotelOrder entity);
        Task<IList<HotelOrder>> GetAllAsync();
        Task<IList<HotelOrder>> WhereAsync(Expression<Func<HotelOrder, bool>> predicate);
        Task<HotelOrder> GetByIdAsync(long id);
        Task<long> UpdateAsync(HotelOrder entity);
        Task RemoveAsync(HotelOrder entity);
        Task<IList<HotelOrder>> IncludeAsync(params string[] relations);
    }
}
