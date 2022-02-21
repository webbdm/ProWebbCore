using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProWebbCore.Api.Models;
using ProWebbCore.Api.Models.Life.Nutrition;
using ProWebbCore.Shared.Life.Nutrition;


namespace ProWebbCore.Api.Controllers.Life.Nutrition
{

    [Route("api/[controller]")]
    [ApiController]
    public class GoalController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IGoalRepository _goalRepository;

        public GoalController(AppDbContext appDbContext, IGoalRepository goalRepository)
        {
            _appDbContext = appDbContext;
            _goalRepository = goalRepository;
        }

        [HttpGet("{id:int}")]
        public Goal GetGoalByID(int id)
        {
            return _goalRepository.GetGoalByID(id);
        }

        [HttpPut]
        public Goal UpdateGoal([FromBody] Goal goal)
        {
            return _goalRepository.UpdateGoal(goal);
        }

    }
}
