using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<MealDTO> GetMeals()
        {
            var meals = _appDbContext.Meal.ToList();
            var mealData = new List<MealDTO>();

            foreach (var meal in meals)
            {
                var query = (from mealfood in _appDbContext.Set<MealFood>().Where(m => m.MealId == meal.Id)
                             join food in _appDbContext.Set<Food>()
                             on mealfood.FoodId equals food.Id
                             select new MealFoodDTO
                             {
                                 Id = mealfood.Id,
                                 FoodId = food.Id,
                                 MealId = mealfood.MealId,
                                 Name = food.Name,
                                 Brand = food.Brand,
                                 Carbohydrate = food.Carbohydrate,
                                 Fat = food.Fat,
                                 Protein = food.Protein
                             }).ToList();


                mealData.Add(new MealDTO {

                    Id = meal.Id,
                    Name = meal.Name,
                    Date = meal.Date,
                    Foods = query
                });

            }

            return mealData;
        }

        [HttpPost("addFood")]
        public MealFoodDTO AddFoodToMeal([FromBody] MealFood mealFood)
        {
            _appDbContext.MealFood.Add(mealFood);
            _appDbContext.SaveChanges();

            var food =  _appDbContext.Food.Where(f=>f.Id == mealFood.FoodId).FirstOrDefault();

            return new MealFoodDTO() {
                    Id = mealFood.Id, 
                    MealId = mealFood.MealId,
                    FoodId = mealFood.FoodId,
                    Name = food.Name,
                    Brand = food.Brand,
                    Protein = food.Protein,
                    Carbohydrate = food.Carbohydrate,
                    Fat = food.Fat
                    };
        }

        [HttpDelete]
        [Route("deleteFood/{id}")]
        public StatusCodeResult DeleteFoodToMeal(int id)
        {
            MealFood food = _appDbContext.MealFood.Find(id);
            _appDbContext.Remove(food);
            _appDbContext.SaveChanges();

            return Ok();

        }
    }
}
