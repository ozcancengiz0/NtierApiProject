using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository<Room> _repository;

        public RoomService(IRepository<Room> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Room entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Room>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Room> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Room entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Room entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Room>> WhereAsync(Expression<Func<Room, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
