using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ResumeId { get; set; }
    }
}
