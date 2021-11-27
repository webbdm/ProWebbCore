using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Numbers
{
    public class Note
    {
        [Key]
        public int ID { get; set; }
        public string NoteName { get; set; }
    }
}
