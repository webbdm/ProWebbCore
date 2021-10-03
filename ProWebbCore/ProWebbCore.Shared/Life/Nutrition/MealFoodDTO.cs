using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class MealFoodDTO
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }
    }
}
