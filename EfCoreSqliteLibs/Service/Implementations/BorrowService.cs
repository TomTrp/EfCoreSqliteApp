using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces.Borrowed;
using EfCoreSqliteLibs.Repository.Interfaces.Borrowed;
using AutoMapper;

namespace EfCoreSqliteLibs.Service.Implementations.Borrowed
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _repo;
        private readonly IMapper _mapper;
        public BorrowService(IBorrowRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<BorrowReadDto?> GetBorrowAsync(int borrowId)
        {
            Borrow? borrow = await _repo.GetAsync(borrowId);
            if (borrow == null) return null;

            return _mapper.Map<BorrowReadDto>(borrow);
        }

        public async Task<List<BorrowReadDto>> GetAllBorrowedAsync()
        {
            List<Borrow> borrowed = await _repo.GetAllAsync();
            return _mapper.Map<List<BorrowReadDto>>(borrowed);
        }

        public async Task<Borrow> CreateBorrowAsync(BorrowCreateDto dto)
        {
            Borrow borrow = _mapper.Map<Borrow>(dto);
            return await _repo.AddAsync(borrow);
        }
    }
}
