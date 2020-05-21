using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProWebbCore.Shared;

namespace ProWebbCore.Api.Models
{
    public class SkillRepository : ISkillRepository
    {
        private readonly AppDbContext _appDbContext;

        public SkillRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Skill CreateSkill(int resumeId, Skill skill)
        {

            var skillToAdd = new Skill {
                Name = skill.Name,
                ResumeId = resumeId,
                YearsExperience = skill.YearsExperience
            };

            var addedEntity = _appDbContext.Skills.Add(skillToAdd);
            _appDbContext.SaveChanges();

            return addedEntity.Entity;
        }
    }
}