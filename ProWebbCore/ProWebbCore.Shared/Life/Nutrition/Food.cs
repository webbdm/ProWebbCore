using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Protein { get; set; }
        public int Carbohydrate { get; set; }
        public int Fat { get; set; }



        //public List<Food> Foods { get; set; }
    }
}
