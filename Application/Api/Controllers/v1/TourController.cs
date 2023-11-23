using AutoMapper;
using DomainModel.Entities;
using DomainModel.UnitOfWork;
using DomainService.Abstrack;
using Dto.Request.Tour;
using Dto.Response.Tour;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TourController(ITourService tourService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _tourService = tourService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] TourAddRequest request)
        {
            try
            {
                var tour = _mapper.Map<Tour>(request);
                var newTour = await _tourService.AddAsync(tour);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = newTour });
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
            var tours = await _tourService.IncludeAsync("Rotations");
            return Ok(new { data = _mapper.Map<IList<TourGetResponse>>(tours) });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(long id)
        {
            var tour = await _tourService.GetByIdAsync(id);
            return Ok(_mapper.Map<TourGetResponse>(tour));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] TourUpdateRequest request)
        {
            try
            {
                var tour = _mapper.Map<Tour>(request);
                var updatedTour = await _tourService.UpdateAsync(tour);
                await _unitOfWork.CommitTransactionAsync();
                return Ok(new { id = updatedTour });
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
                var tour = await _tourService.GetByIdAsync(id);
                await _tourService.RemoveAsync(tour);
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
