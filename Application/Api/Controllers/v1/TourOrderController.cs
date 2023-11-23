using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Tour;
using Dto.Request.TourOrder;
using Dto.Response.Tour;
using Dto.Response.TourOrder;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class TourOrderController : ControllerBase
    {
        private readonly ITourOrderService _tourOrderService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourOrderController(ITourOrderService tourOrderService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tourOrderService = tourOrderService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TourOrderAddRequest request)
        {
            try
            {
                var tourOrder = _mapper.Map<TourOrder>(request);
                var newTourOrder = await _tourOrderService.AddAsync(tourOrder);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newTourOrder });
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
            var tourOrders = await _tourOrderService.IncludeAsync("Customers", "Agent", "Tour");
            return Ok(new { data = _mapper.Map<IList<TourOrderGetResponse>>(tourOrders) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var tourOrder = await _tourOrderService.GetByIdAsync(id);
            return Ok(_mapper.Map<TourOrderGetResponse>(tourOrder));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TourOrderUpdateRequest request)
        {
            try
            {
                var tourOrder = _mapper.Map<TourOrder>(request);
                var updatedTourOrder = await _tourOrderService.UpdateAsync(tourOrder);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedTourOrder });
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
                var tourOrder = await _tourOrderService.GetByIdAsync(id);
                await _tourOrderService.RemoveAsync(tourOrder);
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
