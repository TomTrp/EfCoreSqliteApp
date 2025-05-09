using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Repository.Interfaces
{
    public interface IBorrowRepository
    {
        Task<Borrow?> GetAsync(int borrowId);
        Task<List<Borrow>> GetAllAsync();
        Task<Borrow> AddAsync(Borrow data);
    }
}
