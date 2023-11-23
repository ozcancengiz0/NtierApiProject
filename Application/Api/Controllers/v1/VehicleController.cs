using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Customer;
using Dto.Request.Vehicle;
using Dto.Response.Customer;
using Dto.Response.Vecihle;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleController(IVehicleService vehicleService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _vehicleService = vehicleService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] VehicleAddRequest request)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(request);
                var newVehicle = await _vehicleService.AddAsync(vehicle);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newVehicle });
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicles = await _vehicleService.GetAllAsync();
            return Ok(new { data = _mapper.Map<IList<VehicleGetResponse>>(vehicles) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            return Ok(_mapper.Map<VehicleGetResponse>(vehicle));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TransferOrderUpdateRequest request)
        {
            try
            {
                var vehicle = _mapper.Map<Vehicle>(request);
                var updatedVehicle = await _vehicleService.UpdateAsync(vehicle);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedVehicle });
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                var vehicle = await _vehicleService.GetByIdAsync(id);
                await _vehicleService.RemoveAsync(vehicle);
                await _unitOfWork.CommitTransactionAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return BadRequest(ex.Message);
            }
        }
    }
}
