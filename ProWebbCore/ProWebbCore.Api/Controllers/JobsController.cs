using ProWebbCore.Api.Models;
using ProWebbCore.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ProWebbCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : Controller
    {
        private readonly IJobRepository _jobRepository;

        public JobController(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        [HttpGet]
        public IActionResult GetAllJobs()
        {
            return Ok(_jobRepository.GetAllJobs());
        }

        [HttpGet("{id}")]
        public IActionResult GetJobById(int id)
        {
            return Ok(_jobRepository.GetJobById(id));
        }

        [HttpPost]
        public IActionResult CreateJob([FromBody] Job job)
        {
            if (job == null)
                return BadRequest();

            // if (user.FirstName == string.Empty || user.LastName == string.Empty)
            // {
            //     ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            // }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdJob = _jobRepository.AddJob(job);

            return Created("job", createdJob);
        }

        [HttpPut]
        public IActionResult UpdateJob([FromBody] Job job)
        {
            if (job == null)
                return BadRequest();

            // if (user.FirstName == string.Empty || user.LastName == string.Empty)
            // {
            //     ModelState.AddModelError("Name/FirstName", "The name or first name shouldn't be empty");
            // }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var jobToUpdate = _jobRepository.GetJobById(job.Id);

            if (jobToUpdate == null)
                return NotFound();

            _jobRepository.UpdateJob(job);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteJob(int id)
        {
            if (id == 0)
                return BadRequest();

            var jobToDelete = _jobRepository.GetJobById(id);
            if (jobToDelete == null)
                return NotFound();

            _jobRepository.DeleteJob(id);

            return NoContent();//success
        }
    }
}
