using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class Goal
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Calories { get; set; }
    }
}
