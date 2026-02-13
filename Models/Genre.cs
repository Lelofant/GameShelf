using System.ComponentModel.DataAnnotations;

namespace GameShelf.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [MaxLength(500)]
        public string? Description { get; set; }

        public ICollection<Game>? Games { get; set; }

    }
}
