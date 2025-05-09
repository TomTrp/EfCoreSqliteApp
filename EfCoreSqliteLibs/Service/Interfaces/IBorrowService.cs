using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;

namespace EfCoreSqliteLibs.Service.Interfaces
{
    public interface IBorrowService
    {
        Task<BorrowReadDto?> GetBorrowAsync(int borrowId);
        Task<List<BorrowReadDto>> GetAllBorrowedAsync();
        Task<Borrow> CreateBorrowAsync(BorrowCreateDto dto);
    }
}
