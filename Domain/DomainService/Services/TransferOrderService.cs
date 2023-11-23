using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;

namespace DomainService.Services
{
    public class TransferOrderService : ITransferOrderService
    {
        private readonly IRepository<TransferOrder> _repository;

        public TransferOrderService(IRepository<TransferOrder> repository)
        {
            _repository = repository;
        }

        public async Task<long> AddAsync(TransferOrder entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<IList<TransferOrder>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TransferOrder> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<TransferOrder>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(TransferOrder entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task<long> UpdateAsync(TransferOrder entity)
        {
            await _repository.UpdateAsync(entity);
            return entity.Id;
        }

        public async Task<IList<TransferOrder>> WhereAsync(Expression<Func<TransferOrder, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
