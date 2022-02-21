using System;
using System.Linq;
using ProWebbCore.Shared.Life.Nutrition;

namespace ProWebbCore.Api.Models.Life.Nutrition
{
    public class GoalRepository : IGoalRepository
    {
        private readonly AppDbContext _appDbContext;

        public GoalRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Goal GetGoalByID(int id)
        {
            return _appDbContext.Goal.FirstOrDefault(g => g.ID == id);
        }
    }
}
