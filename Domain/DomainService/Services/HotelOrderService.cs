using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class HotelOrderService:IHotelOrderService
    {
        private readonly IRepository<HotelOrder> _repository;

        public HotelOrderService(IRepository<HotelOrder> repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(HotelOrder entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<IList<HotelOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<HotelOrder> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<HotelOrder>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(HotelOrder entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(HotelOrder entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<HotelOrder>> WhereAsync(Expression<Func<HotelOrder, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
