using System.ComponentModel.DataAnnotations;

namespace GameShelf.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Manufacturer { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; } 

        public ICollection<Game>? Games { get; set; }   
    }
}
