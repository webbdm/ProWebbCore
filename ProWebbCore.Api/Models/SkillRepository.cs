using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Skill> GetAllSkills()
        {
            return _appDbContext.Skills;
        }

        public Skill GetSkillById(int id)
        {
            return _appDbContext.Skills.FirstOrDefault(c => c.Id == id);
        }
    }
}