using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class TourService:ITourService
    {
        private readonly IRepository<Tour> _repository;

        public TourService(IRepository<Tour> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Tour entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Tour>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Tour> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<Tour>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(Tour entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Tour entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Tour>> WhereAsync(Expression<Func<Tour, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
