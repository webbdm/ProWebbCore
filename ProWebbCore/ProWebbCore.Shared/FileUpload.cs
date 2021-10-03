using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    public class FileUpload
    {
        [Key]
        public int Id { get; set; }
        public int EntityID { get; set; }
        public string EntityType { get; set; }
        public string FileName { get; set; }
    }
}
