using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class VehicleService:IVehicleService
    {
        private readonly IRepository<Vehicle> _repository;

        public VehicleService(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Vehicle entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Vehicle>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Vehicle> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Vehicle entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Vehicle entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Vehicle>> WhereAsync(Expression<Func<Vehicle, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
