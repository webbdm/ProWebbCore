using System;
using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared.Auth
{
    public class AccessToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
    }
}
