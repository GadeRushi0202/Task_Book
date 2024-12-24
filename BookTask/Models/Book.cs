using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookTask.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Author is required")]
        public string? Author { get; set; }

        public string? Genre { get; set; }

        [Required(ErrorMessage = "Published Year is required")]
        [Range(1800, int.MaxValue, ErrorMessage = "Published Year must be between 1800 and the current year.")]
        public int PublishedYear { get; set; }
    }
}
