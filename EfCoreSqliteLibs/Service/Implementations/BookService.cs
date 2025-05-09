using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces;
using EfCoreSqliteLibs.Repository.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using EfCoreSqliteLibs.Exceptions;

namespace EfCoreSqliteLibs.Service.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;
        public BookService(IBookRepository repo, IMapper mapper, ILogger<BookService> logger)
        {
            _repo = repo;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Book?> GetBookAsync(int bookId)
        {
            try
            {
                Book? book = await _repo.GetAsync(bookId);
                return book ?? throw new NotFoundException($"book {bookId} not found");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when getting book");
                throw new ServiceException("Cannot get book, try again later");
            }
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            try
            {
                List<Book> books = await _repo.GetAllAsync();
                return books;
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when getting books");
                throw new ServiceException("Cannot get books, try again later");
            }
        }

        public async Task<Book> CreateBookAsync(BookCreateDto dto)
        {
            try
            {
                Book book = _mapper.Map<Book>(dto);
                return await _repo.AddAsync(book);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, "Database error when add book");
                throw new ServiceException("Cannot add books, try again later");
            }
        }
    }
}
