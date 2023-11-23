using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface IAgentService
    {
        Task<long> AddAsync(Agent entity);
        Task<IList<Agent>> GetAllAsync();
        Task<IList<Agent>> WhereAsync(Expression<Func<Agent, bool>> predicate);
        Task<Agent> GetByIdAsync(long id);
        Task<long> UpdateAsync(Agent entity);
        Task RemoveAsync(Agent entity);
    }
}
