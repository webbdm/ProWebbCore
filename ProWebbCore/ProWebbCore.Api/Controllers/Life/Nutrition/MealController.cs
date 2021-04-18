using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProWebbCore.Api.Models;
using ProWebbCore.Shared.Life.Nutrition;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProWebbCore.Api.Controllers.Life.Nutrition
{

    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public MealController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Meal>GetMeals()
        {
            var meals = _appDbContext.Meal.ToList();
            return meals;
        }
    }
}
