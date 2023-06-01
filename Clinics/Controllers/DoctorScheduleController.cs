using AutoMapper;
using Clinics.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinics.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorScheduleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        [HttpGet("{SpecializationId}")]
        public async Task<IActionResult> GetDoctorSchedules(int SpecializationId, int page, int pageSize)
        {
            var schedules = await _unitOfWork.DoctorSchedule.GetDoctorSchedulesAsync(SpecializationId,page, pageSize);

            if (schedules == null)
            {
                return NotFound(); // Return 404 Not Found status code
            }

            return Ok(schedules);
        }


    }
}
