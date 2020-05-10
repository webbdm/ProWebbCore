using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    class Resume
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; } 
    }
}
