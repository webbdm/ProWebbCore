using System;
using ProWebbCore.Shared.Life.Nutrition;

namespace ProWebbCore.Api.Models.Life.Nutrition
{
    public interface IGoalRepository
    {
        Goal GetGoalByID(int id);
        Goal UpdateGoal(Goal goal);
    }
}
