using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces;
using EfCoreSqliteLibs.Repository.Interfaces;
using AutoMapper;
using EfCoreSqliteLibs.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreSqliteLibs.Service.Implementations
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowService> _logger;

        public BorrowService(IBorrowRepository repo, IMapper mapper, ILogger<BorrowService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<BorrowReadDto?> GetBorrowAsync(int borrowId)
        {
            try
            {
                Borrow? borrow = await _repo.GetAsync(borrowId);
                return _mapper.Map<BorrowReadDto>(borrow) ?? throw new NotFoundException($"Borrow {borrowId} not found");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when getting borrow data");
                throw new ServiceException("Cannot get borrow data, try again later");
            }
        }

        public async Task<List<BorrowReadDto>> GetAllBorrowedAsync()
        {
            try
            {
                List<Borrow> borrowed = await _repo.GetAllAsync();
                return _mapper.Map<List<BorrowReadDto>>(borrowed);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when getting borrowed data");
                throw new ServiceException("Cannot get borrowed data, try again later");
            }
        }

        public async Task<Borrow> CreateBorrowAsync(BorrowCreateDto dto)
        {
            try
            {
                Borrow borrow = _mapper.Map<Borrow>(dto);
                return await _repo.AddAsync(borrow);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when add borrow data");
                throw new ServiceException("Cannot add borrow data, try again later");
            }
        }
    }
}
