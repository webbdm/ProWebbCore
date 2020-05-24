using System.Collections.Generic;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public interface ISkillRepository
    {
        Skill CreateSkill(int resumeId, Skill skill);
    }
}