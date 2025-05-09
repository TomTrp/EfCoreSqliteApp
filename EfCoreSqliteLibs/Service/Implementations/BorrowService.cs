using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces;
using EfCoreSqliteLibs.Repository.Interfaces;
using AutoMapper;
using EfCoreSqliteLibs.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EfCoreSqliteLibs.Service.Implementations
{
    public class BorrowService : IBorrowService
    {
        private readonly IBorrowRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<BorrowService> _logger;
        private readonly AppDbContext _context;

        public BorrowService(IBorrowRepository repo, IMapper mapper, ILogger<BorrowService> logger, AppDbContext context)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
            _context = context;
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

        public async Task<List<BorrowReadDto>> GetAllBorrowsAsync()
        {
            try
            {
                List<Borrow> borrowed = await _repo.GetAllAsync();
                return _mapper.Map<List<BorrowReadDto>>(borrowed);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when getting borrows data");
                throw new ServiceException("Cannot get borrows data, try again later");
            }
        }

        public async Task<Borrow> CreateBorrowAsync(BorrowCreateDto dto)
        {
            try
            {
                Borrow borrow = _mapper.Map<Borrow>(dto);

                if (!await _repo.IsBookAvailableAsync(borrow.BookId))
                {
                    throw new BadRequestException($"Book with ID {borrow.BookId} is already borrowed.");
                }

                return await _repo.AddAsync(borrow);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when add borrow data");
                throw new ServiceException("Cannot add borrow data, try again later");
            }
        }

        public async Task<List<Borrow>> CreateMultipleBorrowAsync(BorrowCreateManyDto dto)
        {
            using var trn = await _context.Database.BeginTransactionAsync();
            try
            {
                List<Borrow> borrows = [];
                foreach (int bookId in dto.BookIds)
                {
                    if (!await _repo.IsBookAvailableAsync(bookId))
                    {
                        throw new BadRequestException($"Book with ID {bookId} is already borrowed.");
                    }

                    Borrow borrow = new()
                    {
                        BookId = bookId,
                        BorrowUserId = dto.BorrowUserId,
                        BorrowDate = dto.BorrowDate,
                        Status = "Borrowed"
                    };
                    borrows.Add(borrow);
                }

                await _repo.AddMultipleAsync(borrows);
                await trn.CommitAsync();

                return borrows;
            }
            catch (DbUpdateException ex)
            {
                await trn.RollbackAsync();
                _logger.LogError(ex, "Database error when add borrow data");
                throw new ServiceException("Cannot add borrow data, try again later");
            }
        }

        public async Task<Borrow> UpdateBorrowAsync(int borrowId)
        {
            try
            {
                Borrow? borrow = await _repo.GetTrackedByIdAsync(borrowId);
                if (borrow == null)
                {
                    throw new BadRequestException($"Borrow {borrowId} not found");
                }

                borrow.ReturnDate = DateTime.Now;
                borrow.Status = "Returned";

                return await _repo.UpdateAsync(borrow);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when updating borrow data");
                throw new ServiceException("Cannot update borrow data, try again later");
            }
        }

        public async Task<bool> DeleteBorrowAsync(int borrowId)
        {
            try
            {
                Borrow? borrow = await _repo.GetTrackedByIdAsync(borrowId);
                if (borrow == null)
                {
                    throw new NotFoundException($"Borrow {borrowId} not found");
                }
                await _repo.DeleteAsync(borrow);
                return true;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when deleting borrow data");
                throw new ServiceException("Cannot delete borrow data, try again later");
            }
        }
    }
}
