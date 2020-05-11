using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ResumeId { get; set; }
        public int YearsExperience { get; set; }
    }
}
