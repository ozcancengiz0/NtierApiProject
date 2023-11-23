using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository<Hotel> _repository;

        public HotelService(IRepository<Hotel> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Hotel entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Hotel>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }
        public async Task<IList<Hotel>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task<Hotel> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Hotel entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Hotel entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Hotel>> WhereAsync(Expression<Func<Hotel, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
