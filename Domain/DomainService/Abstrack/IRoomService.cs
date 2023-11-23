using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IRoomService
    {
        Task<long> AddAsync(Room entity);
        Task<IList<Room>> GetAllAsync();
        Task<IList<Room>> WhereAsync(Expression<Func<Room, bool>> predicate);
        Task<Room> GetByIdAsync(long id);
        Task<long> UpdateAsync(Room entity);
        Task RemoveAsync(Room entity);
    }
}
