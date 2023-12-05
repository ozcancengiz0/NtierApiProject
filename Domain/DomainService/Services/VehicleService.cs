using DomainModel.Entities;
using DomainModel.Repository;
using DomainService.Abstrack;
using System.Linq.Expressions;
namespace DomainService.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository<Vehicle> _repository;

        public VehicleService(IRepository<Vehicle> repository)
        {
            _repository = repository;
        }
        public async Task<long> AddAsync(Vehicle entity)
        {
            await _repository.AddAsync(entity);
            return entity.Id;
        }

        public async Task<IList<Vehicle>> GetAllAsync()
        {
            var vehicles = await _repository.GetAllAsync();
            if(vehicles == null || vehicles.Count == 0)
            {
                throw new Exception("Not found any vehicle");
            }
            return vehicles;
        }

        public async Task<Vehicle> GetByIdAsync(long vehicleId)
        {
            var vehicle = await _repository.GetByIdAsync(vehicleId);

            if (vehicle != null)
            {
                return vehicle;
            }
            else
            {
                throw new Exception("Vehicle not found");
            }
        }
        public async Task RemoveAsync(long id)
        {
            var vehicle = await _repository.GetByIdAsync(id);
            if (vehicle != null)
            {
                await _repository.RemoveAsync(vehicle);
            }
            else
            {
                throw new Exception("Not found vehicle");
            }
        }

        public async Task<long> UpdateAsync(Vehicle entity)
        {
            var existingVehicle = await GetByIdAsync(entity.Id);

            if (existingVehicle != null)
            {

                existingVehicle.Id = entity.Id;
                existingVehicle.NumberPlate = entity.NumberPlate;
                existingVehicle.ThumbnailImage = entity.ThumbnailImage;
                existingVehicle.Price = entity.Price;

                await _repository.UpdateAsync(existingVehicle);
                return entity.Id;
            }
            else
            {
                throw new Exception("Vehicle not found");
            }


        }

        public async Task<IList<Vehicle>> WhereAsync(Expression<Func<Vehicle, bool>> predicate)
        {
            return await _repository.WhereAsync(predicate);
        }
    }
}
