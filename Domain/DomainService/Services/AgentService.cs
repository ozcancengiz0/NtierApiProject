using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository<Agent> _repository;

        public AgentService(IRepository<Agent> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Agent entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public Task<IList<Agent>> GetAllAsync()
        {
            return _repository.GetAllAsync();
        }

        public async Task<Agent> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task RemoveAsync(Agent entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(Agent entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Agent>> WhereAsync(Expression<Func<Agent, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
