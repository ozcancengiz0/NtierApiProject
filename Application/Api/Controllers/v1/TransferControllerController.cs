using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Customer;
using Dto.Response.Customer;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class TransferOrderController : ControllerBase
    {
        private readonly ITransferOrderService _transferService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransferOrderController(ITransferOrderService transferService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _transferService = transferService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TransferOrderAddRequest request)
        {
            try
            {
                var transfer = _mapper.Map<TransferOrder>(request);
                var newTransfer = await _transferService.AddAsync(transfer);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newTransfer });
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var transfers = await _transferService.IncludeAsync("Agent", "Vehicle");
            return Ok(new { data = _mapper.Map<IList<TransferGetResponse>>(transfers) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var customer = await _transferService.GetByIdAsync(id);
            return Ok(_mapper.Map<TransferGetResponse>(customer));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TransferOrderUpdateRequest request)
        {
            try
            {
                var transfer = _mapper.Map<TransferOrder>(request);
                var updatedTransfer = await _transferService.UpdateAsync(transfer);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedTransfer });
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            try
            {
                var transfer = await _transferService.GetByIdAsync(id);
                await _transferService.RemoveAsync(transfer);
                await _unitOfWork.CommitTransactionAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return NotFound(ex.Message);
            }
        }
    }
}
