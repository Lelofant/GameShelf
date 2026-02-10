using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GameShelf.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Developer { get; set; } = null!;

        [MaxLength(100)]
        public string? Publisher { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [Range(0, 6)]
        public int? Rating { get; set; }

        [StringLength(1000)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        [DataType(DataType.Date)]   
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PurchaseDate { get; set; }

        [Required]
        public int PlatformId { get; set; }

        [Required]
        public int GenreId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        public Platform? Platform { get; set; }
        public Genre? Genre { get; set; }   
    }
}
