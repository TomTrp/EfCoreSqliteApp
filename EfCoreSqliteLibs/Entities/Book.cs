namespace EfCoreSqliteLibs.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
        public int? PublishedYear { get; set; }
        public DateTime? CreateDate { get; set; }

    }
}
