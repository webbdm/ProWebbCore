using ProWebbCore.Api.Models;
using ProWebbCore.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProWebbCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
      private readonly ISkillRepository _skillRepository;
      
      public SkillController(ISkillRepository skillRepository)
      {
        _skillRepository = skillRepository;
      }

      [HttpPost]
      [Route("{userId}/create")]
      public IActionResult CreateSkill(int userId, [FromBody] Skill skill)
      {
        if (skill == null)
           return BadRequest();

        var createdSkill = _skillRepository.CreateSkill(userId, skill);

            return Created("skill", createdSkill);
      }
    }
}