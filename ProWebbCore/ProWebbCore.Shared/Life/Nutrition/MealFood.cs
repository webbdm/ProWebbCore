using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class MealFood
    {
        [Key]
        public int Id { get; set; }
        public int MealId { get; set; }
        public int FoodId { get; set; }
    }
}