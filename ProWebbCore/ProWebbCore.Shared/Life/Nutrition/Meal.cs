using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
