using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Manager;
using Dto.Response.Manager;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ManagerController(IManagerService managerService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _managerService = managerService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] ManagerAddRequest request)
        {
            try
            {
                var manager = _mapper.Map<Manager>(request);
                var newManager = await _managerService.AddAsync(manager);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newManager });
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
            var managers = await _managerService.IncludeAsync("Agent");
            return Ok(new { data = _mapper.Map<IList<ManagerGetResponse>>(managers) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var manager = await _managerService.GetByIdAsync(id);
            return Ok(_mapper.Map<ManagerGetResponse>(manager));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] ManagerUpdateRequest request)
        {
            try
            {
                var manager = _mapper.Map<Manager>(request);
                var updatedManager = await _managerService.UpdateAsync(manager);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedManager });
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
                var manager = await _managerService.GetByIdAsync(id);
                await _managerService.RemoveAsync(manager);
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
