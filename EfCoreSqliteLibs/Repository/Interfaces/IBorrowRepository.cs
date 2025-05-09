using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Repository.Interfaces
{
    public interface IBorrowRepository
    {
        Task<bool> IsBookAvailableAsync(int bookId);
        Task<Borrow?> GetTrackedByIdAsync(int borrowId);
        Task<Borrow?> GetAsync(int borrowId);
        Task<List<Borrow>> GetAllAsync();
        Task<Borrow> AddAsync(Borrow data);
        Task<List<Borrow>> AddMultipleAsync(List<Borrow> borrows);
        Task<Borrow> UpdateAsync(Borrow data);
        Task DeleteAsync(Borrow data);
    }
}
