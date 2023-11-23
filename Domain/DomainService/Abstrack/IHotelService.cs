using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IHotelService
    {
        Task<long> AddAsync(Hotel entity);
        Task<IList<Hotel>> GetAllAsync();
        Task<IList<Hotel>> WhereAsync(Expression<Func<Hotel, bool>> predicate);
        Task<Hotel> GetByIdAsync(long id);
        Task<long> UpdateAsync(Hotel entity);
        Task RemoveAsync(Hotel entity);
        Task<IList<Hotel>> IncludeAsync(params string[] relations);
    }
}
