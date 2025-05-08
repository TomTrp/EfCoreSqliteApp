using System.ComponentModel.DataAnnotations;

namespace EfCoreSqliteLibs.DTO
{
    public class BorrowCreateDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int BorrowUserId { get; set; }
    }

    public class BorrowReadDto
    {
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public string? BookName { get; set; }
        public int BorrowUserId { get; set; }
        public string? BorrowUserName { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
