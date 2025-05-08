using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreSqliteLibs.Entities
{
    public class Borrow
    {
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int BorrowUserId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = string.Empty;


        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;

        [ForeignKey(nameof(BorrowUserId))]
        public User User { get; set; } = null!;
    }
}
