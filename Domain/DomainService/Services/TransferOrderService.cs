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
            var transferOrders = await _repository.GetAllAsync();
            if (transferOrders == null || transferOrders.Count == 0)
            {
                throw new Exception("Not found any order");
            }
            else
            {
                return transferOrders;
            }
        }

        public async Task<TransferOrder> GetByIdAsync(long id, params string[] relations)
        {
            var order = await _repository.IncludeAsync("Agent", "Vehicle");
            var foundOrder = order.FirstOrDefault(x => x.Id == id);
            if (foundOrder == null)
            {
                throw new Exception("Not found order");
            }
            else
            {
                return foundOrder;
            }
        }

        public async Task<IList<TransferOrder>> IncludeAsync(params string[] relations)
        {
            return await _repository.IncludeAsync(relations);
        }

        public async Task RemoveAsync(TransferOrder entity)
        {
            var foundOrder = await _repository.GetByIdAsync(entity.Id);
            if (foundOrder == null)
            {
                throw new Exception("Not found");
            }
            else
            {
                await _repository.RemoveAsync(entity);
            }
        }

        public async Task<long> UpdateAsync(TransferOrder entity)
        {
            var existingOrder = await GetByIdAsync(entity.Id);
            if (existingOrder == null)
            {
                throw new Exception("Update failed");
            }
            else
            {
                existingOrder.Id = entity.Id;
                existingOrder.StartingDate = entity.StartingDate;
                existingOrder.StartingPosition = entity.StartingPosition;
                existingOrder.EndPosition = entity.EndPosition;
                existingOrder.Hostess = entity.Hostess;
                existingOrder.IsActive = entity.IsActive;

                existingOrder.AgentId = entity.AgentId;
                existingOrder.VehicleId = entity.VehicleId;

                await _repository.UpdateAsync(existingOrder);
                return entity.Id;
            }        
        }

        public async Task<IList<TransferOrder>> WhereAsync(Expression<Func<TransferOrder, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
