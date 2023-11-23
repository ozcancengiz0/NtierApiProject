using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Hotel;
using Dto.Request.HotelOrder;
using Dto.Response.Hotel;
using Dto.Response.HotelOrder;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class HotelOrderController : ControllerBase
    {
        private readonly IHotelOrderService _hotelOrderService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelOrderController(IHotelOrderService hotelOrderService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hotelOrderService = hotelOrderService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] HotelOrderAddRequest request)
        {
            try
            {
                var hotelOrder = _mapper.Map<HotelOrder>(request);
                var newHotelOrder = await _hotelOrderService.AddAsync(hotelOrder);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newHotelOrder });
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
            var hotelOrders = await _hotelOrderService.IncludeAsync("Agent", "Room", "Hotel");
            return Ok(new { data = _mapper.Map<IList<HotelOrderGetResponse>>(hotelOrders) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var hotelOrder = await _hotelOrderService.GetByIdAsync(id);
            return Ok(_mapper.Map<HotelOrderGetResponse>(hotelOrder));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] HotelOrderUpdateRequest request)
        {
            try
            {
                var hotelOrder = _mapper.Map<HotelOrder>(request);
                var updatedHotelOrder = await _hotelOrderService.UpdateAsync(hotelOrder);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedHotelOrder });
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
                var hotelOrder = await _hotelOrderService.GetByIdAsync(id);
                await _hotelOrderService.RemoveAsync(hotelOrder);
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
