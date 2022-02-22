using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Life.Nutrition
{
    public class Split
    {
        [Key]
        public int ID { get; set; }
        public int GoalID { get; set; }
        public double ProteinSplit { get; set; }
        public double FatSplit { get; set; }
        public double CarbohydrateSplit { get; set; }

        public Dictionary<string, double> GetSplits()
        {

            return new Dictionary<string, double> {
                { "PROTEIN", this.ProteinSplit},
                { "FAT", this.FatSplit},
                { "CARBOHYDRATES", this.CarbohydrateSplit},
            };
        }
    }
}
