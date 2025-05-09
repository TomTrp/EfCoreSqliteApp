using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Service.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowReadDto?> GetBorrowAsync(int borrowId);
        Task<List<BorrowReadDto>> GetAllBorrowsAsync();
        Task<Borrow> CreateBorrowAsync(BorrowCreateDto dto);
        Task<List<Borrow>> CreateMultipleBorrowAsync(BorrowCreateManyDto dto);
        Task<Borrow> UpdateBorrowAsync(int borrowId);
        Task<bool> DeleteBorrowAsync(int borrowId);
    }
}
