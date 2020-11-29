using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProWebbCore.Shared
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [Column(TypeName = "text")]
        public string Bio { get; set; }

        public List<Resume> Resumes { get; set; }
        public List<Project> Projects { get; set; }
    }
}
