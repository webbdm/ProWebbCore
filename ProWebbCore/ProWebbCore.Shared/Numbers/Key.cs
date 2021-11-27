using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Numbers
{
    public class Key
    {
        [Key]
        public int ID { get; set; }
        public string KeyName { get; set; }
        public List<KeyNote> Notes { get; set; }
    }
}
