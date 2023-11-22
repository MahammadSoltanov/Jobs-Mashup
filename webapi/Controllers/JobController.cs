using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        public JobController(IJobRepository jobRepository)
        {
            _jobRepository  = jobRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var jobs = await _jobRepository.GetAllAsync();

            return Ok(jobs);
        }
    }
}
