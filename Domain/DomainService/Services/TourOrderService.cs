using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class TourOrderService:ITourOrderService
    {
        private readonly IRepository<TourOrder> _repository;

        public TourOrderService(IRepository<TourOrder> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(TourOrder entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<TourOrder>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<TourOrder> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<TourOrder>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(TourOrder entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(TourOrder entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<TourOrder>> WhereAsync(Expression<Func<TourOrder, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
