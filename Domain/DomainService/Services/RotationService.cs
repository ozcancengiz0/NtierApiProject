using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class RotationService:IRotationService
    {
        private readonly IRepository<Rotation> _repository;

        public RotationService(IRepository<Rotation> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Rotation entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Rotation>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Rotation> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Rotation entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Rotation entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Rotation>> WhereAsync(Expression<Func<Rotation, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
