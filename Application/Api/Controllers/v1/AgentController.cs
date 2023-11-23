using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Agent;
using Dto.Response.Agent;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AgentController(IAgentService agentService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _agentService = agentService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] AgentAddRequest request)
        {
            try
            {
                var agent = _mapper.Map<Agent>(request);
                var newAgent = await _agentService.AddAsync(agent);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newAgent });
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
            var agents = await _agentService.GetAllAsync();
            return Ok(new { data = _mapper.Map<IList<AgentGetResponse>>(agents) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var agent = await _agentService.GetByIdAsync(id);
            return Ok(_mapper.Map<AgentGetResponse>(agent));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] AgentUpdateRequest request)
        {
            try
            {
                var agent = _mapper.Map<Agent>(request);
                var updatedAgent = await _agentService.UpdateAsync(agent);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedAgent });
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
                var agent = await _agentService.GetByIdAsync(id);
                await _agentService.RemoveAsync(agent);
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
