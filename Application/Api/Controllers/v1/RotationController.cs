using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Rotation;
using Dto.Response.Rotation;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class RotationController : ControllerBase
    {
        private readonly IRotationService _rotationService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RotationController(IRotationService rotationService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _rotationService = rotationService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RotationAddRequest request)
        {
            try
            {
                var rotation = _mapper.Map<Rotation>(request);
                var newRotation = await _rotationService.AddAsync(rotation);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newRotation });
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
            var rotations = await _rotationService.GetAllAsync();
            return Ok(new { data = _mapper.Map<IList<RotationGetResponse>>(rotations) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var rotation = await _rotationService.GetByIdAsync(id);
            return Ok(_mapper.Map<RotationGetResponse>(rotation));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] RotationUpdateRequest request)
        {
            try
            {
                var rotation = _mapper.Map<Rotation>(request);
                var updatedRotation = await _rotationService.UpdateAsync(rotation);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedRotation });
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
                var rotation = await _rotationService.GetByIdAsync(id);
                await _rotationService.RemoveAsync(rotation);
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
