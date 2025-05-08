using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Repository.Interfaces.Borrowed
{
    public interface IBorrowRepository
    {
        Task<Borrow?> GetAsync(int borrowId);
        Task<List<Borrow>> GetAllAsync();
        Task<Borrow> AddAsync(Borrow data);
    }
}
