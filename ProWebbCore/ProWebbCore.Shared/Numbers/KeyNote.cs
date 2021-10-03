using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Numbers
{
    public class KeyNote
    {
        [Key]
        public int ID { get; set; }
        public int KeyID { get; set; }
        public int NoteID { get; set; }
        public string NoteName { get; set; }
        public int Number { get; set; }
    }
}
