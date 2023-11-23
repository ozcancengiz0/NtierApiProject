using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;
using System.Net.Mail;

namespace DomainService.Services
{
    public class ManagerService : IManagerService
    {
        private readonly IRepository<Manager> _repository;

        public ManagerService(IRepository<Manager> repository) {
            _repository = repository;
        }
        public async Task<long> AddAsync(Manager entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Manager>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Manager> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<Manager>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(Manager entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Manager entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Manager>> WhereAsync(Expression<Func<Manager, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
