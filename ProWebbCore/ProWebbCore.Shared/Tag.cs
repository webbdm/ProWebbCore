using System.ComponentModel.DataAnnotations;

namespace ProWebbCore.Shared
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string EntityType { get; set; }
        public int EntityId { get; set; }
    }
}