using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IVehicleService
    {
        Task<long> AddAsync(Vehicle entity);
        Task<IList<Vehicle>> GetAllAsync();
        Task<IList<Vehicle>> WhereAsync(Expression<Func<Vehicle, bool>> predicate);
        Task<Vehicle> GetByIdAsync(long id);
        Task<long> UpdateAsync(Vehicle entity);
        Task RemoveAsync(long id);
    }
}
