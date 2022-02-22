using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class Goal
    {
        [Key]
        public int ID { get; set; }
        public int UserID { get; set; }
        public int Calories { get; set; }
        public Split Split { get; set; }

        [NotMapped]
        public double Protein { get; set; }
        [NotMapped]
        public double Fat { get; set; }
        [NotMapped]
        public double Carbohydrates { get; set; } 

        public void SetMacros(Split split)
        {
            this.Protein = CalculateMacroTarget("PROTEIN", split);
            this.Fat = CalculateMacroTarget("FAT", split);
            this.Carbohydrates = CalculateMacroTarget("CARBOHYDRATES", split);
        }


        public Dictionary<string, double> GetFactors()
        {

            return new Dictionary<string, double> {
                { "PROTEIN", 4},
                { "FAT", 9},
                { "CARBOHYDRATES", 4},
            };
        }

        public double CalculateMacroTarget(string macro, Split split)
        {
            return Math.Round((this.Calories * (split.GetSplits()[macro]/100)) / GetFactors()[macro]);
        }

    }
}
