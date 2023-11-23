using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Hotel;
using Dto.Response.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HotelController(IHotelService hotelService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _hotelService = hotelService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] HotelAddRequest request)
        {
            try
            {
                var hotel = _mapper.Map<Hotel>(request);
                var newHotel = await _hotelService.AddAsync(hotel);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newHotel });
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
            var hotels = await _hotelService.IncludeAsync("Rooms");
            return Ok(new { data = _mapper.Map<IList<HotelGetResponse>>(hotels) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var hotel = await _hotelService.GetByIdAsync(id);
            return Ok(_mapper.Map<HotelGetResponse>(hotel));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] HotelUpdateRequest request)
        {
            try
            {
                var hotel = _mapper.Map<Hotel>(request);
                var updatedHotel = await _hotelService.UpdateAsync(hotel);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedHotel });
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
                var hotel = await _hotelService.GetByIdAsync(id);
                await _hotelService.RemoveAsync(hotel);
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
