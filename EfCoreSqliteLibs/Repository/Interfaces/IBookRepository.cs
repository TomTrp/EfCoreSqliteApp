using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<Book?> GetAsync(int bookId);
        Task<List<Book>> GetAllAsync();
        Task<Book> AddAsync(Book data);
    }
}
