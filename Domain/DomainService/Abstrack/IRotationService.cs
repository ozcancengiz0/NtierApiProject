using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IRotationService
    {
        Task<long> AddAsync(Rotation entity);
        Task<IList<Rotation>> GetAllAsync();
        Task<IList<Rotation>> WhereAsync(Expression<Func<Rotation, bool>> predicate);
        Task<Rotation> GetByIdAsync(long id);
        Task<long> UpdateAsync(Rotation entity);
        Task RemoveAsync(Rotation entity);
    }
}
