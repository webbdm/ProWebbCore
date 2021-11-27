using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int ImageId { get; set; }
        public string Link { get; set; }
        public string Type { get; set; }
    }
}
