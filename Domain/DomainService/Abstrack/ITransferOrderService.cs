using DomainModel.Entities;
using System.Linq.Expressions;

namespace DomainService.Abstrack
{
    public interface ITransferOrderService
    {
        Task<long> AddAsync(TransferOrder entity);
        Task<IList<TransferOrder>> GetAllAsync();
        Task<IList<TransferOrder>> WhereAsync(Expression<Func<TransferOrder, bool>> predicate);
        Task<TransferOrder> GetByIdAsync(long id,params string[] relations);
        Task<long> UpdateAsync(TransferOrder entity);
        Task RemoveAsync(TransferOrder entity);
        Task<IList<TransferOrder>> IncludeAsync(params string[] relations);
    }
}
