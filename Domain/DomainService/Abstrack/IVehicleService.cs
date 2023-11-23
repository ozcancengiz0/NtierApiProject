using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainService.Abstrack
{
    public interface IVehicleService
    {
        Task<long> AddAsync(Vehicle entity);
        Task<IList<Vehicle>> GetAllAsync();
        Task<IList<Vehicle>> WhereAsync(Expression<Func<Vehicle, bool>> predicate);
        Task<Vehicle> GetByIdAsync(long id);
        Task<long> UpdateAsync(Vehicle entity);
        Task RemoveAsync(Vehicle entity);
    }
}
