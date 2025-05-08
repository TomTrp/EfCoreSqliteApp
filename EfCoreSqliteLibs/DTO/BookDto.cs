using System.ComponentModel.DataAnnotations;

namespace EfCoreSqliteLibs.DTO
{
    public class BookCreateDto
    {
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Author { get; set; } = string.Empty;
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public int? PublishedYear { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
