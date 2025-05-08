using EfCoreSqliteLibs.DTO;
using EfCoreSqliteLibs.Entities;
using EfCoreSqliteLibs.Service.Interfaces.Books;
using EfCoreSqliteLibs.Repository.Interfaces.Books;
using AutoMapper;

namespace EfCoreSqliteLibs.Service.Implementations.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;
        public BookService(IBookRepository repo, IMapper mapper) 
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Book?> GetBookAsync(int bookId)
        {
            return await _repo.GetAsync(bookId);
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<Book> CreateBookAsync(BookCreateDto dto)
        {
            Book book = _mapper.Map<Book>(dto);
            return await _repo.AddAsync(book);
        }
    }
}
