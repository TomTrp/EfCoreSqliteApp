using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Service.Interfaces.Books
{
    public interface IBookService
    {
        Task<Book?> GetBookAsync(int bookId);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> CreateBookAsync(BookCreateDto dto);
    }
}
