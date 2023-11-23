using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Room;
using Dto.Response.Room;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _roomService = roomService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RoomAddRequest request)
        {
            try
            {
                var room = _mapper.Map<Room>(request);
                var newRoom = await _roomService.AddAsync(room);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newRoom });
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
            var rooms = await _roomService.GetAllAsync();
            return Ok(new { data = _mapper.Map<IList<RoomGetResponse>>(rooms) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var room = await _roomService.GetByIdAsync(id);
            return Ok(_mapper.Map<RoomGetResponse>(room));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RoomUpdateRequest request)
        {
            try
            {
                var room = _mapper.Map<Room>(request);
                var updatedRoom = await _roomService.UpdateAsync(room);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedRoom });
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
                var room = await _roomService.GetByIdAsync(id);
                await _roomService.RemoveAsync(room);
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
