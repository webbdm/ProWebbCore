using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProWebbCore.Api.Models;
using ProWebbCore.Shared.Life.Nutrition;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProWebbCore.Api.Controllers.Life.Nutrition
{

    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public FoodController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public List<Food> GetFoods()
        {
            var foods = _appDbContext.Food.FromSqlRaw("Select Id, Name, Brand, Protein, Carbohydrate, Fat from Food").ToList();

            return foods;
        }
    }
}