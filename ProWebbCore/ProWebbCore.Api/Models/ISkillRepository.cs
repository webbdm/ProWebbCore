using System.Collections.Generic;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public interface ISkillRepository
    {
        IEnumerable<Skill> GetAllSkills();
        Skill GetSkillById(int id);
    }
}